using MediatR;
using VendingMachine.Domain.Dtos.OrderItem;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Contracts.Persistence
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem, CancellationToken cancellationToken = default);
    }
}
