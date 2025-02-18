using FluentValidation;
using VendingMachine.Application.Contracts.Persistence;
using VendingMachine.Domain.Dtos.OrderItem;

namespace VendingMachine.Application.Features.Order.Commands.CreateOrder
{
    public class OrderItemValidator : AbstractValidator<OrderItemRequestDto>
    {
        private readonly IProductRepository _productRepository;

        public OrderItemValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(orderItem => orderItem)
                .MustAsync(CheckStock)
                .WithMessage("We're out of stock.");

            RuleFor(orderItem => orderItem)
            .MustAsync(IsQuantityLessThanStock)
                .WithMessage("The quantity must be less than or equal to the available stock.");
        }

        private async Task<bool> CheckStock(OrderItemRequestDto orderItemDto, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(orderItemDto.ProductId, cancellationToken);

            return product.QuantityInStock > 0;
        }

        private async Task<bool> IsQuantityLessThanStock(OrderItemRequestDto orderItemDto, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(orderItemDto.ProductId, cancellationToken);

            return orderItemDto.Quantity <= product.QuantityInStock;
        }
    }
}
