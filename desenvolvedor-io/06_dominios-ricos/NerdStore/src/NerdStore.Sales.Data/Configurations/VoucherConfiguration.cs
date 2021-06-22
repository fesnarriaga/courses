using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Sales.Domain.Entities;

namespace NerdStore.Sales.Data.Configurations
{
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Percent)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Value)
                .HasColumnType("decimal(18,2)");

            // 1 : N => Voucher : Order
            builder.HasMany(v => v.Orders)
                .WithOne(o => o.Voucher)
                .HasForeignKey(o => o.VoucherId);
        }
    }
}
