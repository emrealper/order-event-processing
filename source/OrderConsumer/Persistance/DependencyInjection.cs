using System.Reflection;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.DataAccess;
using Persistance.Repositories;

namespace Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OrderDatabase")));
            services.AddScoped<IOrderDbContext>(provider => provider.GetService<OrderDbContext>());
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}