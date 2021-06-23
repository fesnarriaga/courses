using NerdStore.Core.DomainObjects.Entities;
using NerdStore.Core.Mediator;
using NerdStore.Sales.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Sales.Data.Extensions
{
    public static class MediatorHandlerExtensions
    {
        public static async Task PublishNotifications(this IMediatorHandler mediator, SalesContext context)
        {
            var domainEntities = context.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Events != null && x.Entity.Events.Any())
                .ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Events);

            domainEntities.ForEach(x => x.Entity.ClearEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) => await mediator.RaiseEvent(domainEvent));

            await Task.WhenAll(tasks);
        }
    }
}
