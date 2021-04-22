using CompleteApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompleteApp.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar (200)");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar (1000)");

            builder.Property(x => x.Image)
                .IsRequired();

            builder.HasIndex(x => x.Name)
                .HasDatabaseName("IDX_PRODUCT_NAME");
        }
    }
}
