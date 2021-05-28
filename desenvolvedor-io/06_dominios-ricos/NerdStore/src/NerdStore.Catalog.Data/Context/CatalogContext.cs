using Microsoft.EntityFrameworkCore;
using NerdStore.Catalog.Domain.Entities;
using NerdStore.Core.Interfaces.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Data.Context
{
    public class CatalogContext : DbContext, IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties =
                    entity.GetProperties().Where(x => x.ClrType == typeof(string));

                foreach (var property in properties)
                {
                    if (string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue)
                    {
                        property.SetColumnType("varchar(100)");
                    }
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("CreatedAt").IsModified = false;
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
