using CompleteApp.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CompleteApp.Data.Context
{
    public class CompleteAppContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public CompleteAppContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompleteAppContext).Assembly);

            DisableOnCascadingDelete(modelBuilder);

            SetDefaultValueForStringProperties(modelBuilder);
        }

        private static void DisableOnCascadingDelete(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
        }

        private static void SetDefaultValueForStringProperties(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties =
                    entity.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var property in properties)
                {
                    if (string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue)
                    {
                        property.SetColumnType("varchar(100)");
                    }
                }
            }
        }
    }
}
