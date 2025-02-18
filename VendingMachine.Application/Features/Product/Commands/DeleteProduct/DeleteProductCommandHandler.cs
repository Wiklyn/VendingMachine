using MediatR;
using OneOf;
using VendingMachine.Application.Contracts.Persistence;
using VendingMachine.Domain.Response.Product;

namespace VendingMachine.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, OneOf<Unit, ProductNotFoundResponse>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<OneOf<Unit, ProductNotFoundResponse>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            if (productToDelete == null)
                return new ProductNotFoundResponse(request.Id);

            await _productRepository.DeleteAsync(request.Id, cancellationToken);

            return Unit.Value;
        }
    }
}
