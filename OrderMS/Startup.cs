using AutoMapper;
using Domain.Services.Infrastructure.Mapper;
using FluentValidation.AspNetCore;
using Infra.Crosscutting.Behaviours;
using Infra.Data;
using Infra.Data.EventStore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OrderMS
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddMediatR(typeof(Domain.Services.Features.Order.Commands.CreateOrder.CreateOrderCommand).Assembly);
            services.AddSwagger();
            services.AddAutoMapper(typeof(OrderProfile).Assembly);
            services.AddDbContext<OrderDbContext>(opt =>
                opt.UseInMemoryDatabase("OrderDB"));

            services.AddSingleton<IEventStoreDbContext, EventStoreDbContext>();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(EventLoggerBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseErrorHandling();
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Api");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
