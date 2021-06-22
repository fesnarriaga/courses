using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Interfaces.UnitOfWork;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages;
using NerdStore.Sales.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Sales.Data.Context
{
    public class SalesContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        public SalesContext(DbContextOptions<SalesContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

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

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            modelBuilder.HasSequence<int>("MySequence").StartsAt(1000).IncrementsBy(1);
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
