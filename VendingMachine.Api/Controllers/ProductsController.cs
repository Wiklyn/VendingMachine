using MediatR;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Features.Product.Commands.CreateProduct;
using VendingMachine.Application.Features.Product.Commands.DeleteProduct;
using VendingMachine.Application.Features.Product.Commands.UpdateProduct;
using VendingMachine.Application.Features.Product.Queries;
using VendingMachine.Application.Features.Product.Queries.GetAllProducts;
using VendingMachine.Application.Features.Product.Queries.GetProductById;
using VendingMachine.Domain.Dtos.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VendingMachine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());

            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));

            return result.Match(
                Ok,
                notFound => ProcessError(notFound)
            );
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand createProductCommand)
        {
            var result = await _mediator.Send(createProductCommand);

            return result.Match(
                product => CreatedAtAction(nameof(GetById), new { id = product.Id }, product),
                badRequest => ProcessError(badRequest)
            );
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            var command = new UpdateProductCommand(id, updateProductDto.Name, updateProductDto.Price, updateProductDto.QuantityInStock);

            var result = await _mediator.Send(command);

            return result.Match(
                product => Ok(product),
                notFound => ProcessError(notFound),
                badRequest => ProcessError(badRequest)
            );
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));

            return result.Match(
                _ => NoContent(),
                notFound => ProcessError(notFound)
            );
        }
    }
}
