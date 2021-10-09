using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EventBus
{
    public class EventBusService : IEventBusService
    {
        private static readonly Random rand = new Random();

        private readonly ProducerConfig _producerConfig;

        public EventBusService(IConfiguration config)
        {
            var kafkaHost = config.GetSection("KafkaConfiguration:Host").Value;
            var kafkaPort = config.GetSection("KafkaConfiguration:Port").Value;

            _producerConfig = new ProducerConfig
            {
                BootstrapServers = $"{kafkaHost}:{kafkaPort}"
            };
        }


        public async Task SendEventBusAsync(string message, string topicName)
        {
            //In using statement, we instantiate a producer object.
            //At the end of the using statement block, it automatically calls Dispose() method
            //We ensure that the resource release from memory
            using var producer = new ProducerBuilder<string, string>(_producerConfig).Build();
            await producer.ProduceAsync(topicName,
                new Message<string, string> {Key = rand.Next(5).ToString(), Value = message});
        }
    }
}