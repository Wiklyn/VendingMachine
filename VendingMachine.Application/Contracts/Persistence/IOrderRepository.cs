using MediatR;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Contracts.Persistence
{
    public interface IOrderRepository
    {
        Task<IReadOnlyList<Order>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Order> CreateAsync(Order requestEntity, CancellationToken cancellationToken = default);
    }
}
