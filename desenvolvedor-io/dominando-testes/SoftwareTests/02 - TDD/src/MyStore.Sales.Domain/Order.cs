using FluentValidation.Results;
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

        public Voucher Voucher { get; set; }

        public bool VoucherApplied { get; set; }

        public decimal Discount { get; set; }

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
                if (orderItemExists != null)
                {
                    var orderItemQuantity = orderItem.Quantity + orderItemExists.Quantity;

                    orderItem = new OrderItem(
                        orderItem.ProductId,
                        orderItem.ProductName,
                        orderItem.ProductPrice,
                        orderItemQuantity);
                }

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

        public void RemoveOrderItem(OrderItem orderItem)
        {
            ValidateNonExistingOrderItem(orderItem);

            _orderItems.Remove(orderItem);

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

        public ValidationResult ApplyVoucher(Voucher voucher)
        {
            var validationResult = voucher.Applicable();

            if (!validationResult.IsValid)
                return validationResult;

            Voucher = voucher;
            VoucherApplied = true;

            CalculateRedeemTotal();

            return validationResult;
        }

        private void CalculateRedeemTotal()
        {
            if (!VoucherApplied)
                return;

            var discount = 0M;

            if (Voucher.DiscountType == VoucherDiscountType.Cash)
            {
                if (Voucher.CashDiscount.HasValue)
                {
                    discount = Voucher.CashDiscount.Value;
                }
            }
            else
            {
                if (Voucher.PercentDiscount.HasValue)
                {
                    discount = (Total * Voucher.PercentDiscount.Value) / 100;
                }
            }

            Total -= discount;
            Discount = discount;
        }

        private void ValidateMaxOrderItemsQuantity(OrderItem orderItem)
        {
            var quantity = orderItem.Quantity;

            if (OrderItemExists(orderItem))
            {
                var existingOrderItem = _orderItems.FirstOrDefault(x => x.ProductId == orderItem.ProductId);

                if (existingOrderItem != null)
                {
                    quantity += existingOrderItem.Quantity;
                }
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
