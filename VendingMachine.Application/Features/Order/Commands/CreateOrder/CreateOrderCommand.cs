using MediatR;
using OneOf;
using VendingMachine.Domain.Dtos.OrderItem;
using VendingMachine.Domain.Response.Order;
using VendingMachine.Domain.Response.Product;

namespace VendingMachine.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<OneOf<Domain.Entities.Order, OrderBadRequestResponse, ProductNotFoundResponse>>
    {
        public List<OrderItemRequestDto> OrderProducts { get; set; } = [];
    }
}
