using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services.Features.Order.Events.OrderCreated
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