using System;

namespace NerdStore.Core.Messages.IntegrationEvents
{
    public class StockDecreaseFailedEvent : IntegrationEvent
    {
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }

        public StockDecreaseFailedEvent(Guid customerId, Guid orderId)
        {
            AggregateId = orderId;
            CustomerId = customerId;
            OrderId = orderId;
        }
    }
}
