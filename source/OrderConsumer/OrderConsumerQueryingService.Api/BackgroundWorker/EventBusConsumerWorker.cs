using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OrderConsumerQueryingService.Api.BackgroundWorker
{
    public class EventBusConsumerWorker : BackgroundService
    {
        private readonly IConsumerService _consumerService;
        private readonly ILogger<EventBusConsumerWorker> _logger;

        public EventBusConsumerWorker(ILogger<EventBusConsumerWorker> logger, IConsumerService consumerService)
        {
            _logger = logger;
            _consumerService = consumerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) await _consumerService.SubscribeServiceBusAsync();
        }
    }
}