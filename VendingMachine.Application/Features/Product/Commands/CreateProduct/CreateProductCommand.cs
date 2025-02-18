using MediatR;
using OneOf;
using VendingMachine.Domain.Dtos.Product;
using VendingMachine.Domain.Response.Product;

namespace VendingMachine.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<OneOf<ProductResponseDto, ProductBadRequestResponse>>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
    }
}
