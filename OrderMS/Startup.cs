using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using OrderMS.Data;
using OrderMS.Data.EventStore;
using OrderMS.Infrastructure.Behaviours;
using OrderMS.Infrastructure.Mapper;
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

            services.AddMediatR(typeof(Startup).Assembly);
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
