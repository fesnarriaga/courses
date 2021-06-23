﻿using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Application.Events
{
    public class OrderItemAddedEvent : Event
    {
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public OrderItemAddedEvent(
            Guid customerId,
            Guid orderId,
            Guid productId,
            string productName,
            decimal price,
            int quantity)
        {
            AggregateId = orderId;
            CustomerId = customerId;
            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }
    }
}
