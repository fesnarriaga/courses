﻿using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Application.Events
{
    public class DraftOrderStartedEvent : Event
    {
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }

        public DraftOrderStartedEvent(Guid customerId, Guid orderId)
        {
            AggregateId = orderId;
            CustomerId = customerId;
            OrderId = orderId;
        }
    }
}
