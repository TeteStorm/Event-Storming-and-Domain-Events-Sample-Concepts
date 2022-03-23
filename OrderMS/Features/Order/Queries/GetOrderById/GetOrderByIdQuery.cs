using MediatR;
using OrderMS.Dto;

namespace OrderMS.Features.Order.Queries.GetOrderById
{
    public record GetOrderByIdQuery(int OrderId) : IRequest<OrderDto>;
}