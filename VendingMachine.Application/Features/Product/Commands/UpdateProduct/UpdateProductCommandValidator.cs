using FluentValidation;

namespace VendingMachine.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(product => product.Price)
                .GreaterThan(0)
                .WithMessage("The price must be greater than 0.");

            RuleFor(product => product.Name)
                .NotEmpty()
                .WithMessage("The product must have a name.");

            RuleFor(product => product.QuantityInStock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The quantity in stock must be greater than or equal to 0.");
        }
    }
}
