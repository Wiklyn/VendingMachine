using FluentValidation;

namespace VendingMachine.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(order => order.OrderProducts.Count)
                .GreaterThan(0)
                .WithMessage("The order cannot be empty.");
        }
    }
}
