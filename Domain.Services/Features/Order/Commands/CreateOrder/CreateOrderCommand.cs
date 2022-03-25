using OrderMS.Dto;
using MediatR;

namespace OrderMS.Features.Order.Commands.CreateOrder
{
    public record CreateOrderCommand(int ClientId, decimal TotalValue) : IRequest<OrderDto>;
}