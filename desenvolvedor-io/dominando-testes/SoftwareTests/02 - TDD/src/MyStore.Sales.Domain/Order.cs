using System.Collections.Generic;
using System.Linq;

namespace MyStore.Sales.Domain
{
    public class Order
    {

        #region Fields and Properties
        private readonly List<OrderItem> _orderItems;

        public decimal Total { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        #endregion

        #region Constructors
        public Order()
        {
            _orderItems = new List<OrderItem>();
        }
        #endregion

        #region Methods
        public void AddOrderItem(OrderItem orderItem)
        {
            _orderItems.Add(orderItem);

            Total = _orderItems.Sum(x => x.Quantity * x.ProductPrice);
        }
        #endregion
    }
}
