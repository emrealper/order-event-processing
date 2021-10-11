using System.Reflection;
using Application.Interfaces;
using Application.Interfaces.Common;
using Application.Services.Commands.Order;
using Infrastructure.DataHelpers;
using Infrastructure.EventBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IConsumerService, ConsumerService>();
            services.AddSingleton<IProducerService, ProducerService>();
            services.AddTransient<IDeserializeKafkaMessage<CreateOrderCommand>>(s =>
                new DeserializeKafkaMessageToCommand<CreateOrderCommand>());
            return services;
        }
    }
}