using MediatR;
using OneOf;
using VendingMachine.Domain.Dtos.Product;
using VendingMachine.Domain.Response.Product;

namespace VendingMachine.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<OneOf<ProductResponseDto, ProductNotFoundResponse>>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
