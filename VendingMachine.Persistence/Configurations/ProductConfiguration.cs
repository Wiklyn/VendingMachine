using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.Name).IsRequired().HasMaxLength(50);
            builder.Property(product => product.Price).HasColumnType("decimal(4, 2)").IsRequired();
            builder.Property(product => product.QuantityInStock).HasDefaultValue(0);

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Coca-Cola (12 oz can)",
                    Price = 1.50M,
                    QuantityInStock = 10
                },
                new Product
                {
                    Id = 2,
                    Name = "Doritos (1.75 oz bag)",
                    Price = 1.75M,
                    QuantityInStock = 7
                },
                new Product
                {
                    Id = 3,
                    Name = "Snickers Bar",
                    Price = 1.25M,
                    QuantityInStock = 3
                },
                new Product
                {
                    Id = 4,
                    Name = "Bottled Water (16.9 oz)",
                    Price = 1.00M,
                    QuantityInStock = 0
                },
                new Product
                {
                    Id = 5,
                    Name = "M&M’s (1.69 oz pack)",
                    Price = 1.50M,
                    QuantityInStock = 5
                },
                new Product
                {
                    Id = 6,
                    Name = "Red Bull (8.4 oz can)",
                    Price = 2.50M,
                    QuantityInStock = 2
                }
            );
        }
    }
}
