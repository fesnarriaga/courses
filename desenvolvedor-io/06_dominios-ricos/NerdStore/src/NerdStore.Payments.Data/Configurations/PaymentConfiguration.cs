using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Payments.Business.Entities;

namespace NerdStore.Payments.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Total)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.CardName)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.CardNumber)
                .IsRequired()
                .HasColumnType("varchar(16)");

            builder.Property(x => x.CardExpiresAt)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(x => x.CardCode)
                .IsRequired()
                .HasColumnType("varchar(4)");

            // 1 : 1 => Payment : Transaction
            builder.HasOne(p => p.Transaction)
                .WithOne(t => t.Payment);
        }
    }
}
