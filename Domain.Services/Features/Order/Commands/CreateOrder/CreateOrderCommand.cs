using Domain.Services.Dto;
using MediatR;

namespace Domain.Services.Features.Order.Commands.CreateOrder
{
    public record CreateOrderCommand(int ClientId, decimal TotalValue) : IRequest<OrderDto>;
}