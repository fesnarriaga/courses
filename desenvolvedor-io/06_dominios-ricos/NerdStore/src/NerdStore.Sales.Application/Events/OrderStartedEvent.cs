﻿using NerdStore.Core.DomainObjects.Dtos;
using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Application.Events
{
    public class OrderStartedEvent : Event
    {
        public Guid CustomerId { get; private set; }
        public Guid OrderId { get; private set; }
        public decimal Total { get; private set; }
        public OrderProductList ProductList { get; private set; }
        public string CardName { get; private set; }
        public string CardNumber { get; private set; }
        public string CardExpiresAt { get; private set; }
        public string CardCode { get; private set; }

        public OrderStartedEvent(
            Guid customerId,
            Guid orderId,
            decimal total,
            OrderProductList productList,
            string cardName,
            string cardNumber,
            string cardExpiresAt,
            string cardCode)
        {
            AggregateId = orderId;
            CustomerId = customerId;
            OrderId = orderId;
            Total = total;
            ProductList = productList;
            CardName = cardName;
            CardNumber = cardNumber;
            CardExpiresAt = cardExpiresAt;
            CardCode = cardCode;
        }
    }
}
