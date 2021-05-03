using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Sales.Domain
{
    public class Order
    {

        #region Fields and Properties

        private readonly List<OrderItem> _orderItems;

        public Guid CustomerId { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        public decimal Total { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        #endregion

        #region Constructors

        protected Order()
        {
            _orderItems = new List<OrderItem>();
        }

        #endregion

        #region Methods

        public void AddOrderItem(OrderItem orderItem)
        {
            var orderItemExists = _orderItems.Find(x => x.ProductId == orderItem.ProductId);

            if (orderItemExists != null)
            {
                orderItem = new OrderItem(
                    orderItem.ProductId,
                    orderItem.ProductName,
                    orderItem.ProductPrice,
                    orderItem.Quantity + orderItemExists.Quantity);

                _orderItems.Remove(orderItemExists);
            }

            _orderItems.Add(orderItem);

            CalculateTotalOrder();
        }

        public void CalculateTotalOrder()
        {
            Total = _orderItems.Sum(x => x.CalculateTotalOrderItem());
        }

        public void MakeDraft()
        {
            OrderStatus = OrderStatus.Draft;
        }

        #endregion

        #region Factories

        public static class OrderFactory
        {
            public static Order NewOrderDraft(Guid customerId)
            {
                var order = new Order
                {
                    CustomerId = customerId
                };

                order.MakeDraft();

                return order;
            }
        }

        #endregion
    }
}
