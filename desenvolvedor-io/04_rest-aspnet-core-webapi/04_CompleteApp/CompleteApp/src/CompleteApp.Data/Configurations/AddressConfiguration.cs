using CompleteApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompleteApp.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Street)
                .IsRequired()
                .HasColumnType("varchar (200)");

            builder.Property(x => x.Number)
                .IsRequired()
                .HasColumnType("varchar (50)");

            builder.Property(x => x.Complement)
                .IsRequired()
                .HasColumnType("varchar (200)");

            builder.Property(x => x.District)
                .IsRequired()
                .HasColumnType("varchar (100)");

            builder.Property(x => x.City)
                .IsRequired()
                .HasColumnType("varchar (100)");

            builder.Property(x => x.State)
                .IsRequired()
                .HasColumnType("varchar (50)");

            builder.Property(x => x.PostalCode)
                .IsRequired()
                .HasColumnType("varchar (8)");

            builder.HasIndex(x => x.PostalCode)
                .HasDatabaseName("IDX_ADDRESS_POSTAL_CODE");
        }
    }
}
