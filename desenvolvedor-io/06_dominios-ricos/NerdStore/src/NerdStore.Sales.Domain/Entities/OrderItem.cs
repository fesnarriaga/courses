using NerdStore.Core.DomainObjects.Entities;
using System;

namespace NerdStore.Sales.Domain.Entities
{
    public class OrderItem : Entity
    {
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        // FK
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }

        // EF Relation
        public Order Order { get; private set; }

        protected OrderItem() { }

        public OrderItem(Guid orderId, string productName, int quantity, decimal price)
        {
            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        internal void SetOrder(Guid orderId)
        {
            OrderId = orderId;
        }

        public decimal GetTotal()
        {
            return Quantity * Price;
        }

        internal void IncreaseQuantity(int value)
        {
            Quantity += value;
        }

        internal void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
