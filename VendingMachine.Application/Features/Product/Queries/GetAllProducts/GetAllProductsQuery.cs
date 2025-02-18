using MediatR;
using VendingMachine.Domain.Dtos.Product;

namespace VendingMachine.Application.Features.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductResponseDto>>
    {
    }
}
