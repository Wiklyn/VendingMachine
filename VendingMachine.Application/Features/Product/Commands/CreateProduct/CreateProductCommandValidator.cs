using FluentValidation;
using VendingMachine.Application.Contracts.Persistence;

namespace VendingMachine.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(product => product)
                .MustAsync(ProductNameUnique)
                .WithMessage("Product is already in the stock.");

            RuleFor(product => product.Price)
                .GreaterThan(0)
                .WithMessage("The price must be greater than 0.");

            RuleFor(product => product.QuantityInStock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The quantity in stock must be greater than or equal to 0.");

            RuleFor(product => product.Name)
                .NotEmpty()
                .WithMessage("The product must have a name."); ;
        }

        private async Task<bool> ProductNameUnique(CreateProductCommand command, CancellationToken token)
        {
            return !await _productRepository.CheckIfExists(command.Name);
        }
    }
}
