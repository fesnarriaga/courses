using NerdStore.Core.Messages;
using System;

namespace NerdStore.Core.DomainObjects.Events
{
    public abstract class DomainEvent : Event
    {
        protected DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
