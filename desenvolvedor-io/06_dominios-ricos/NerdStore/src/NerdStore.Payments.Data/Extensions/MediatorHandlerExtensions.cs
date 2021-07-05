using NerdStore.Core.DomainObjects.Entities;
using NerdStore.Core.Mediator;
using NerdStore.Payments.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Payments.Data.Extensions
{
    public static class MediatorHandlerExtensions
    {
        public static async Task PublishNotifications(this IMediatorHandler mediator, PaymentsContext context)
        {
            var domainEntities = context.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Events != null && x.Entity.Events.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Events)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.RaiseEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
