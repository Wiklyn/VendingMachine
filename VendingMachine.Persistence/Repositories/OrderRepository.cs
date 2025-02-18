using Microsoft.EntityFrameworkCore;
using VendingMachine.Application.Contracts.Persistence;
using VendingMachine.Domain.Entities;
using VendingMachine.Persistence.DatabaseContext;

namespace VendingMachine.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly VendingMachineDbContext _context;

        public OrderRepository(VendingMachineDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateAsync(Order requestEntity, CancellationToken cancellationToken = default)
        {
            await _context.Set<Order>().AddAsync(requestEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return requestEntity;
        }

        public async Task<IReadOnlyList<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Order>()
                .AsNoTracking()
                .Include(o => o.OrderProducts)
                .ThenInclude(oi => oi.Product)
                .ToListAsync(cancellationToken);
        }

        public async Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Order>()
                .Include(o => o.OrderProducts)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }
    }
}
