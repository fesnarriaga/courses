using MyStore.Core.Exceptions;
using System;

namespace MyStore.Sales.Domain
{
    public class OrderItem
    {
        #region Fields and Properties

        public Guid ProductId { get; private set; }

        public string ProductName { get; private set; }

        public decimal ProductPrice { get; private set; }

        public int Quantity { get; private set; }

        #endregion

        #region Constructors

        public OrderItem(Guid productId, string productName, decimal productPrice, int quantity)
        {
            if (quantity < Order.MinItemsPerOrder)
                throw new DomainException($"Min of {Order.MinItemsPerOrder} items per order item");

            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            Quantity = quantity;
        }

        #endregion

        #region Methods

        internal void AddQuantity(int amount)
        {
            Quantity += amount;
        }

        internal decimal CalculateTotalOrderItem()
        {
            return ProductPrice * Quantity;
        }

        #endregion
    }
}
