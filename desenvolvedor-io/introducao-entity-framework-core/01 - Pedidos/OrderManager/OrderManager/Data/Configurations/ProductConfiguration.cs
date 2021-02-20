using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Domain;

namespace OrderManager.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.BarCode)
                .HasColumnType("VARCHAR(14)")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("VARCHAR(60)");

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.ProductType)
                .HasConversion<string>();
        }
    }
}
