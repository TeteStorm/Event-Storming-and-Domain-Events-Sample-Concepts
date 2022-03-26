using Domain.Services.Dto;
using Domain.Services.Features.Order.Commands.CreateOrder;
using Domain.Services.Features.Order.Queries.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace OrderMS.Features.Order
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns a Order filtered by id.
        /// </summary>
        /// <param name="OrderId">Order ID</param>
        /// <returns>Order Details</returns>
        [HttpGet("{OrderId:int}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int OrderId)
        {
            OrderDto Order = await _mediator.Send(new GetOrderByIdQuery(OrderId));
            return Ok(Order);
        }

        /// <summary>
        /// Creates a new Order.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Orders
        ///     {
        ///        "ClientId": "1",
        ///        "TotalValue": "10.0000"
        ///     }
        ///
        /// </remarks>
        /// <param name="createOrderCommand">New Order data include FirstName and LastName.</param>
        /// <returns>New created Order</returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand createOrderCommand)
        {
            OrderDto Order = await _mediator.Send(createOrderCommand);
            return CreatedAtAction(nameof(GetOrderById), new { OrderId = Order.Id }, Order);
        }
    }
}
