using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Domain;

namespace OrderManager.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR(80)")
                .IsRequired();

            builder.Property(x => x.Phone)
                .HasColumnType("CHAR(11)");

            builder.Property(x => x.PostalCode)
                .HasColumnType("CHAR(8)")
                .IsRequired();

            builder.Property(x => x.State)
                .HasColumnType("CHAR(2)")
                .IsRequired();

            builder.Property(x => x.City)
                .HasMaxLength(60)
                .IsRequired();

            builder.HasIndex(x => x.Phone)
                .HasDatabaseName("IDX_CUSTOMER_PHONE");
        }
    }
}
