using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalog.Domain.Entities;

namespace NerdStore.Catalog.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(p => p.Image)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.OwnsOne(p => p.Dimensions, r =>
            {
                r.Property(d => d.Width)
                    .HasColumnName("Width")
                    .HasColumnType("decimal(18, 2)");

                r.Property(d => d.Height)
                    .HasColumnName("Height")
                    .HasColumnType("decimal(18, 2)");

                r.Property(d => d.Depth)
                    .HasColumnName("Depth")
                    .HasColumnType("decimal(18, 2)");
            });
        }
    }
}
