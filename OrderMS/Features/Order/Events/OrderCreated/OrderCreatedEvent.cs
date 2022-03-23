using MediatR;
using System;

namespace OrderMS.Features.Order.Events.OrderCreated
{
    public record OrderCreatedEvent(int ClientId, decimal TotalValue, DateTime RegistrationDate) : INotification;
}
