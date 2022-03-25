using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Services.Features.Order.Events.OrderCreated
{
    public class OrderCreatedEmailSenderHandler : INotificationHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            //IMessageSender.SendMail("xpto.system@xptomail.com,",$"Order {notification.Id} created",$"Order {notification.Id} created with value {notification.TotalValue} for client {notification.ClientId}!");
            return Task.CompletedTask;
        }
    }
}