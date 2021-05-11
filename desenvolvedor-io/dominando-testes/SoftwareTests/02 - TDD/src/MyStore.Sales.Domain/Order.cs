using MyStore.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Sales.Domain
{
    public class Order
    {
        #region Fields and Properties

        public const int MaxItemsPerOrder = 15;
        public const int MinItemsPerOrder = 1;

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
            ValidateMaxOrderItemsQuantity(orderItem);

            var orderItemExists = _orderItems.Find(x => x.ProductId == orderItem.ProductId);

            if (OrderItemExists(orderItem))
            {
                var orderItemQuantity = orderItem.Quantity + orderItemExists.Quantity;

                orderItem = new OrderItem(
                    orderItem.ProductId,
                    orderItem.ProductName,
                    orderItem.ProductPrice,
                    orderItemQuantity);

                _orderItems.Remove(orderItemExists);
            }

            _orderItems.Add(orderItem);

            CalculateTotalOrder();
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            ValidateNonExistingOrderItem(orderItem);
            ValidateMaxOrderItemsQuantity(orderItem);

            var orderItemExists = _orderItems.FirstOrDefault(x => x.ProductId == orderItem.ProductId);

            _orderItems.Remove(orderItemExists);
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

        private void ValidateMaxOrderItemsQuantity(OrderItem orderItem)
        {
            var quantity = orderItem.Quantity;

            if (OrderItemExists(orderItem))
            {
                var existingOrderItem = _orderItems.FirstOrDefault(x => x.ProductId == orderItem.ProductId);

                quantity += existingOrderItem.Quantity;
            }

            if (quantity > MaxItemsPerOrder)
                throw new DomainException($"Max of {MaxItemsPerOrder} items per order item");
        }

        private bool OrderItemExists(OrderItem orderItem)
        {
            return _orderItems.Any(x => x.ProductId == orderItem.ProductId);
        }

        private void ValidateNonExistingOrderItem(OrderItem orderItem)
        {
            if (!OrderItemExists(orderItem))
                throw new DomainException("Order item do not exists");
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
