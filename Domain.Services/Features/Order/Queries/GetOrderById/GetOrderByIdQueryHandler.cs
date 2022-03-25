using AutoMapper;
using MediatR;
using Infra.Data;
using Domain.Services.Dto;
using System.Net;
using Infra.Crosscutting.Exceptions;

namespace Domain.Services.Features.Order.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            Core.Order order = await _context.Orders
                .FindAsync(request.OrderId);

            if (order == null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Order with given ID is not found.");
            }

            return _mapper.Map<OrderDto>(order);
        }
    }
}