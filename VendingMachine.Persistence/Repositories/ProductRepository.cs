using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OneOf;
using VendingMachine.Application.Contracts.Persistence;
using VendingMachine.Domain.Dtos.Product;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Response.Base;
using VendingMachine.Persistence.DatabaseContext;

namespace VendingMachine.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly VendingMachineDbContext _context;

        public ProductRepository(VendingMachineDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfExists(string name)
        {
            return await _context.Products.AnyAsync(product => product.Name == name);
        }

        public async Task<Product> CreateAsync(Product requestEntity, CancellationToken cancellationToken = default)
        {
            await _context.Set<Product>().AddAsync(requestEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return requestEntity;
        }

        public async Task<OneOf<Unit, ApiNotFoundResponse>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var existingEntity = await _context.Set<Product>().FindAsync([id], cancellationToken);

            if (existingEntity == null)
            {
                string entityName = typeof(Request).Name;
                return new ApiNotFoundResponse($"{entityName} with Id {id} Not Found.");
            }

            _context.Set<Product>().Remove(existingEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().FindAsync([id], cancellationToken);
        }

        public async Task<OneOf<Unit, ApiNotFoundResponse>> UpdateAsync(int id, ProductRequestDto requestEntity, CancellationToken cancellationToken = default)
        {
            var existingEntity = await _context.Set<Product>().FindAsync([id], cancellationToken);

            if (existingEntity == null)
            {
                string entityName = typeof(Request).Name;
                return new ApiNotFoundResponse($"{entityName} with Id {id} Not Found.");
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(requestEntity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
