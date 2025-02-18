using MediatR;
using OneOf;
using VendingMachine.Domain.Response.Base;

namespace VendingMachine.Application.Contracts.Persistence
{
    public interface IGenericRepository<Request, Response>
        where Request : class
        where Response : class
    {
        Task<IReadOnlyList<Response>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Response> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<Unit> CreateAsync(Request requestEntity, CancellationToken cancellationToken = default);
        Task<OneOf<Unit, ApiNotFoundResponse>> UpdateAsync(int id, Request requestEntity, CancellationToken cancellationToken = default);
        Task<OneOf<Unit, ApiNotFoundResponse>> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
