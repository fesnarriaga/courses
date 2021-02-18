using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Domain;

namespace OrderManager.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StartDate)
                .HasDefaultValue("GETDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.OrderStatus)
                .HasConversion<string>();

            builder.Property(x => x.DeliveryChargeType)
                .HasConversion<int>();

            builder.Property(x => x.Notes)
                .HasColumnType("VARCHAR(512)");

            builder.HasMany(x => x.OrderItems)
                .WithOne(i => i.Order)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
