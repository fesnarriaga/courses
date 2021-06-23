using NerdStore.Core.Messages.DomainEvents;
using System;

namespace NerdStore.Catalog.Domain.Events
{
    public class MinimumStockAmountEvent : DomainEvent
    {
        public int RemainingStockAmount { get; private set; }

        public MinimumStockAmountEvent(Guid aggregateId, int remainingStockAmount) : base(aggregateId)
        {
            RemainingStockAmount = remainingStockAmount;
        }
    }
}
