using MediatR;
using System;

namespace Domain.Services.Features.Order.Events.OrderCreated
{
    public record OrderCreatedEvent(int ClientId, decimal TotalValue, DateTime RegistrationDate) : INotification;
}
