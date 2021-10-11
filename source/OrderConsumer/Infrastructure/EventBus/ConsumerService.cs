using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.Commands.Order;
using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Retry;

namespace Infrastructure.EventBus
{
    public class ConsumerService : IConsumerService
    {
        private readonly ConsumerConfig _consumerConfig;
        private readonly IDeserializeKafkaMessage<CreateOrderCommand> _deserializeKafkaMessage;
        private readonly IMediator _mediator;
        private readonly IProducerService _producerService;
        private readonly AsyncRetryPolicy _retryPolicy;
        private readonly string _retryTopic;
        private readonly string _topic;


        public ConsumerService(IConfiguration config, IProducerService producerService, IMediator mediator,
            IDeserializeKafkaMessage<CreateOrderCommand> deserializeKafkaMessage)
        {
            var kafkaHost = config.GetSection("KafkaConfiguration:Host").Value;
            var kafkaPort = config.GetSection("KafkaConfiguration:Port").Value;
            var groupId = config.GetSection("KafkaConfiguration:GroupId").Value;

            _deserializeKafkaMessage = deserializeKafkaMessage;
            _producerService = producerService;
            _topic = config.GetSection("KafkaConfiguration:Topic").Value;
            _retryTopic = config.GetSection("KafkaConfiguration:RetryTopic").Value;
            _mediator = mediator;
            _consumerConfig = new ConsumerConfig
            {
                BootstrapServers = $"{kafkaHost}:{kafkaPort}",
                GroupId = groupId
            };


            //defined retry policy in case of failing
            _retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(2, retryAttempt =>
                    {
                        var timeToWait = TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
                        Console.WriteLine($"Waiting {timeToWait.TotalSeconds} seconds");
                        return timeToWait;
                    }
                );
        }

        public async Task SubscribeServiceBusAsync()
        {
            using var consumer = new ConsumerBuilder<Ignore, string>(_consumerConfig).Build();
            consumer.Subscribe(_topic);
            var cts = new CancellationTokenSource();
            try
            {
                while (true)
                {
                    var consumeResult = consumer.Consume(cts.Token);
                    //try to execute consumed message 
                    if (!await TryConsume(consumeResult, cts))
                        //if it fails, send message to the dead letter queue / retry topic
                        await _producerService.SendEventBusAsync(consumeResult.Message.Value, _retryTopic);
                }
            }
            finally
            {
                // Ensure the consumer leaves the group cleanly and final offsets are committed.
                consumer.Close();
            }
        }


        private async Task<bool> TryConsume(ConsumeResult<Ignore, string> consumeResult, CancellationTokenSource token)
        {
            try
            {
                //Deserialize kafka message 
                var createOrderCommand = _deserializeKafkaMessage.Deserialize(consumeResult.Message.Value);
                //try to save order aggregate to the database using retry policy.
                //After 2 attempt send it dead letter queue
                await _retryPolicy.ExecuteAsync(async () => await _mediator.Send(createOrderCommand));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}