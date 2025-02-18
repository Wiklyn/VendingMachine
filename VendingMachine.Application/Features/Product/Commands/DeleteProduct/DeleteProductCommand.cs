using MediatR;
using OneOf;
using VendingMachine.Domain.Response.Product;

namespace VendingMachine.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<OneOf<Unit, ProductNotFoundResponse>>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
