using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Interfaces.UnitOfWork;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages;
using NerdStore.Payments.Business.Entities;
using NerdStore.Payments.Data.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Payments.Data.Context
{
    public class PaymentsContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public PaymentsContext(DbContextOptions<PaymentsContext> options, IMediatorHandler mediatorHandler) : base(options)
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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentsContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
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

            var success = await base.SaveChangesAsync() > 0;

            if (success)
                await _mediatorHandler.PublishNotifications(this);

            return success;
        }
    }
}
