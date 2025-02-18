using VendingMachine.Application.Contracts.Persistence;
using VendingMachine.Domain.Entities;
using VendingMachine.Persistence.DatabaseContext;

namespace VendingMachine.Persistence.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        protected readonly VendingMachineDbContext _context;

        public OrderItemRepository(VendingMachineDbContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem, CancellationToken cancellationToken = default)
        {
            await _context.Set<OrderItem>().AddAsync(orderItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return orderItem;
        }
    }
}
