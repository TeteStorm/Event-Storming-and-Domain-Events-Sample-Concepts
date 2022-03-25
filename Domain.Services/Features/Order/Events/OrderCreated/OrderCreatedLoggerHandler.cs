using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services.Features.Order.Events.OrderCreated
{
    public class OrderCreatedLoggerHandler : INotificationHandler<OrderCreatedEvent>
    {
        private readonly ILogger<OrderCreatedLoggerHandler> _logger;

        public OrderCreatedLoggerHandler(ILogger<OrderCreatedLoggerHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"New Order has been created at {notification.RegistrationDate}: total value {notification.TotalValue} client {notification.ClientId}");

            return Task.CompletedTask;
        }
    }
}