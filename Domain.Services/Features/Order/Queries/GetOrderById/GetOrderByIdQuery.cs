using MediatR;
using Domain.Services.Dto;

namespace Domain.Services.Features.Order.Queries.GetOrderById
{
    public record GetOrderByIdQuery(int OrderId) : IRequest<OrderDto>;
}