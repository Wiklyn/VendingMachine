using AutoMapper;
using MediatR;
using OneOf;
using VendingMachine.Application.Contracts.Persistence;
using VendingMachine.Domain.Dtos.Product;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Response.Order;
using VendingMachine.Domain.Response.Product;

namespace VendingMachine.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OneOf<Domain.Entities.Order, OrderBadRequestResponse, ProductNotFoundResponse>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<OneOf<Domain.Entities.Order, OrderBadRequestResponse, ProductNotFoundResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            List<OrderItem> orderItemsList = [];

            // Order items validation
            var orderItemDtoValidator = new OrderItemValidator(_productRepository);

            foreach (var item in request.OrderProducts)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId, cancellationToken);

                if (product == null)
                    return new ProductNotFoundResponse(item.ProductId);

                var orderItem = _mapper.Map<OrderItem>(item);
                orderItem.Product = product;
                orderItem.ProductId = product.Id;

                var orderItemValidationResult = await orderItemDtoValidator.ValidateAsync(item, cancellationToken);

                if (orderItemValidationResult.Errors.Count > 0)
                    return new OrderBadRequestResponse(orderItemValidationResult);

                orderItemsList.Add(orderItem);
            }

            // Order validation
            var orderValidator = new CreateOrderCommandValidator();
            var orderValidationResult = await orderValidator.ValidateAsync(request, cancellationToken);

            if (orderValidationResult.Errors.Count > 0)
                return new OrderBadRequestResponse(orderValidationResult);

            var orderToCreate = new Domain.Entities.Order(orderItemsList);
            await _orderRepository.CreateAsync(orderToCreate, cancellationToken);

            foreach (var item in orderItemsList)
            {
                item.Id = 0;
                item.OrderId = orderToCreate.Id;
                await _orderItemRepository.CreateOrderItemAsync(item, cancellationToken);
            }

            var orderProducts = orderToCreate.OrderProducts.ToList();

            foreach (var item in orderProducts)
            {
                ProductRequestDto updatedProduct = new()
                {
                    Name = item.Product.Name,
                    Price = item.Product.Price,
                    QuantityInStock = item.Product.QuantityInStock - item.Quantity,
                };

                await _productRepository.UpdateAsync(item.ProductId, updatedProduct, cancellationToken);
            }

            return orderToCreate;
        }
    }
}
