using AutoMapper;
using MediatR;
using OrderMS.Data;
using OrderMS.Dto;
using OrderMS.Infrastructure.Exceptions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OrderMS.Features.Order.Queries.GetOrderById
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
            Domain.Order order = await _context.Orders
                .FindAsync(request.OrderId);

            if (order == null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Order with given ID is not found.");
            }

            return _mapper.Map<OrderDto>(order);
        }
    }
}