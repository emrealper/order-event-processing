using Application;
using Application.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using OrderConsumerQueryingService.Api.BackgroundWorker;
using OrderConsumerQueryingService.Api.Middleware;
using Persistance;
using HostedServices = Microsoft.Extensions.Hosting;

namespace OrderConsumerQueryingService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddInfrastructure();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Order Consumer Api", Version = "v1"});
            });
            services
                .AddControllersWithViews()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IOrderDbContext>());
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                loggingBuilder.AddNLog();
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Consumer Api V1"); });

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            //efcore migration on startup
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService <OrderDbContext> ();
                context?.Database.Migrate();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCustomExceptionHandler();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}