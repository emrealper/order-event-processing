using Application.Interfaces;
using Infrastructure.EventBus;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //By using AddSingleton we create single instance of the EventBusService
            //When we first requested and reuse the same instance where it needed
            services.AddSingleton<IEventBusService, EventBusService>();
            return services;
        }
    }
}