using CompleteApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompleteApp.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar (200)");

            builder.Property(x => x.Document)
                .IsRequired()
                .HasColumnType("varchar (14)");

            // 1:1 => Supplier : Address
            builder.HasOne(x => x.Address)
                .WithOne(a => a.Supplier);

            // 1:N => Supplier : Products
            builder.HasMany(x => x.Products)
                .WithOne(p => p.Supplier);

            builder.HasIndex(x => x.Document)
                .HasDatabaseName("IDX_SUPPLIER_DOCUMENT");
        }
    }
}
