using MediatR;
using OneOf;
using VendingMachine.Domain.Dtos.Product;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Response.Base;

namespace VendingMachine.Application.Contracts.Persistence
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Product> CreateAsync(Product requestEntity, CancellationToken cancellationToken = default);
        Task<OneOf<Unit, ApiNotFoundResponse>> UpdateAsync(int id, ProductRequestDto requestEntity, CancellationToken cancellationToken = default);
        Task<OneOf<Unit, ApiNotFoundResponse>> DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> CheckIfExists(string name);
    }
}
