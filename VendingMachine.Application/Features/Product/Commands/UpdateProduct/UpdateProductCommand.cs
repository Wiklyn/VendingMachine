using MediatR;
using OneOf;
using VendingMachine.Domain.Dtos.Product;
using VendingMachine.Domain.Response.Product;

namespace VendingMachine.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<OneOf<ProductResponseDto, ProductNotFoundResponse, ProductBadRequestResponse>>
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int QuantityInStock { get; }

        public UpdateProductCommand(int id, string name, decimal price, int quantityInStock)
        {
            Id = id;
            Name = name;
            Price = price;
            QuantityInStock = quantityInStock;
        }
    }
}
