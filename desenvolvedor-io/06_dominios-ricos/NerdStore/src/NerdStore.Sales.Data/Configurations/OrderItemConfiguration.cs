using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Sales.Domain.Entities;

namespace NerdStore.Sales.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)");

            // N : 1 => OrderItem : Order
            builder.HasOne(i => i.Order)
                .WithMany(o => o.Items);
        }
    }
}
