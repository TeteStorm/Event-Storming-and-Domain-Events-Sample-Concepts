using MediatR;
using OrderMS.Infrastructure.Services;
using System.Threading;
using System.Threading.Tasks;

namespace OrderMS.Features.Order.Events.OrderCreated
{
    public class OrderCreatedCreditAnalysisHandler : INotificationHandler<OrderCreatedEvent>
    {
       // private IProducer<OrderCreatedEvent> _producer;
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            //await _producer.SendAsync(notification);
            return Task.CompletedTask;
        }
    }
}