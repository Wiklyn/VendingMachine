using Microsoft.EntityFrameworkCore;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Persistence.DatabaseContext
{
    public class VendingMachineDbContext : DbContext
    {
        public VendingMachineDbContext(DbContextOptions<VendingMachineDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendingMachineDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
