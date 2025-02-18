using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using VendingMachine.Application.Contracts.Persistence;
using VendingMachine.Domain.Response.Base;
using VendingMachine.Persistence.DatabaseContext;

namespace VendingMachine.Persistence.Repositories
{
    public class GenericRepository<Request, Response> : IGenericRepository<Request, Response>
        where Request : class
        where Response : class
    {
        protected readonly VendingMachineDbContext _context;

        public GenericRepository(VendingMachineDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> CreateAsync(Request requestEntity, CancellationToken cancellationToken = default)
        {
            await _context.Set<Request>().AddAsync(requestEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<OneOf<Unit, ApiNotFoundResponse>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var existingEntity = await _context.Set<Request>().FindAsync([id], cancellationToken);

            if (existingEntity == null)
            {
                string entityName = typeof(Request).Name;
                return new ApiNotFoundResponse($"{entityName} with Id {id} Not Found.");
            }

            _context.Set<Request>().Remove(existingEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<IReadOnlyList<Response>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Response>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Response> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Response>().FindAsync([id], cancellationToken);
        }

        public async Task<OneOf<Unit, ApiNotFoundResponse>> UpdateAsync(int id, Request entity, CancellationToken cancellationToken = default)
        {
            var existingEntity = await _context.Set<Response>().FindAsync([id], cancellationToken);

            if (existingEntity == null)
            {
                string entityName = typeof(Request).Name;
                return new ApiNotFoundResponse($"{entityName} with Id {id} Not Found.");
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
