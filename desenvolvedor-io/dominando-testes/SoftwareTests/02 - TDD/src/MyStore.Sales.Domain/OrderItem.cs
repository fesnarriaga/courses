using System;

namespace MyStore.Sales.Domain
{
    public class OrderItem
    {
        #region Fields and Properties
        public Guid Id { get; private set; }

        public string ProductName { get; private set; }

        public decimal ProductPrice { get; private set; }

        public int Quantity { get; private set; }
        #endregion

        #region Constructors
        public OrderItem(Guid id, string productName, decimal productPrice, int quantity)
        {
            Id = id;
            ProductName = productName;
            ProductPrice = productPrice;
            Quantity = quantity;
        }
        #endregion

        #region Methods

        #endregion
    }
}
