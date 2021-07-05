using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Application.Commands
{
    public class CancelOrderProcessAndRollbackStockCommand : Command
    {
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }

        public CancelOrderProcessAndRollbackStockCommand(Guid customerId, Guid orderId)
        {
            AggregateId = orderId;
            CustomerId = customerId;
            OrderId = orderId;
        }
    }
}
