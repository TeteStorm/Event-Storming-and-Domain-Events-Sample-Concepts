using AutoMapper;
using MediatR;
using OrderMS.Data;
using OrderMS.Dto;
using OrderMS.Features.Order.Events.OrderCreated;
using System.Threading;
using System.Threading.Tasks;

namespace OrderMS.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateOrderCommandHandler(OrderDbContext context,
            IMapper mapper,
            IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand createOrderCommand, CancellationToken cancellationToken)
        {
            Domain.Order order = _mapper.Map<Domain.Order>(createOrderCommand);

            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            // Raising Event ...
            await _mediator.Publish(new OrderCreatedEvent(order.ClientId, order.TotalValue, order.RegistrationDate), cancellationToken);

            return _mapper.Map<OrderDto>(order);
        }
    }
}