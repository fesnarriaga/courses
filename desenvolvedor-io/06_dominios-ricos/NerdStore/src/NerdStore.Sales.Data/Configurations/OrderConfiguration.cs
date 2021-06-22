using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Sales.Domain.Entities;

namespace NerdStore.Sales.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .HasDefaultValueSql("NEXT VALUE FOR MySequence");

            builder.Property(x => x.Discount)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Total)
                .HasColumnType("decimal(18,2)");

            // 1 : N => Order : OrderItem
            builder.HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId);
        }
    }
}
