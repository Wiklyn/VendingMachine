using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Features.Order.Commands.CreateOrder;
using VendingMachine.Application.Features.Order.Queries.GetAllOrders;
using VendingMachine.Application.Features.Order.Queries.GetOrderById;
using VendingMachine.Domain.Dtos.Order;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendingMachine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());

            return Ok(orders);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(id));

            return result.Match(
                Ok,
                error => ProcessError(error)
            );
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderCommand createOrderCommand)
        {
            var result = await _mediator.Send(createOrderCommand);

            return result.Match(
                order => CreatedAtAction(nameof(GetById), new { id = order.Id }, order),
                badRequest => ProcessError(badRequest),
                productNotFound => ProcessError(productNotFound)
            );
        }
    }
}
