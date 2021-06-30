using FluentValidation.Results;
using NerdStore.Core.DomainObjects.Entities;
using NerdStore.Core.DomainObjects.Exceptions;
using NerdStore.Core.DomainObjects.Interfaces;
using NerdStore.Sales.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NerdStore.Sales.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        private readonly List<OrderItem> _orderItems;

        public int Code { get; private set; }
        public OrderStatus Status { get; private set; }
        public bool AppliedVoucher { get; private set; }
        public decimal Discount { get; private set; }
        public decimal Total { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _orderItems;

        // FK
        public Guid? VoucherId { get; private set; }
        public Guid CustomerId { get; private set; }

        // EF Relation
        public Voucher Voucher { get; private set; }

        protected Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public Order(Guid customerId, bool appliedVoucher, decimal discount, decimal total)
        {
            CustomerId = customerId;
            AppliedVoucher = appliedVoucher;
            Discount = discount;
            Total = total;

            _orderItems = new List<OrderItem>();
        }

        public ValidationResult ApplyVoucher(Voucher voucher)
        {
            var validationResult = voucher.CanApply();
            if (!validationResult.IsValid)
                return validationResult;

            Voucher = voucher;
            AppliedVoucher = true;
            CalculateTotal();

            return validationResult;
        }

        public void CalculateTotal()
        {
            Total = Items.Sum(x => x.GetTotal());
            CalculateDiscount();
        }

        public void CalculateDiscount()
        {
            if (!AppliedVoucher)
                return;

            var discount = 0M;
            var total = Total;

            if (Voucher.Type == VoucherType.Percent)
            {
                if (Voucher.Percent.HasValue)
                {
                    discount = (total * Voucher.Percent.Value) / 100;
                }
            }
            else
            {
                if (Voucher.Value.HasValue)
                {
                    discount = Voucher.Value.Value;
                }
            }

            total -= discount;

            Total = total < 0 ? 0 : total;
            Discount = discount;
        }

        public void AddItem(OrderItem item)
        {
            if (!item.IsValid())
                return;

            item.SetOrder(Id);

            if (OrderItemExists(item))
            {
                var existingItem = _orderItems.FirstOrDefault(x => x.ProductId == item.ProductId);
                existingItem?.IncreaseQuantity(item.Quantity);
                item = existingItem;

                _orderItems.Remove(existingItem);
            }

            _orderItems.Add(item);
            CalculateTotal();
        }

        public void RemoveItem(OrderItem item)
        {
            if (!item.IsValid())
                return;

            var existingItem = Items.FirstOrDefault(x => x.ProductId == item.ProductId);

            if (existingItem is null)
                throw new DomainException("OrderItem not found");

            _orderItems.Remove(item);
            CalculateTotal();
        }

        public void UpdateItem(OrderItem item)
        {
            if (!item.IsValid())
                return;

            item.SetOrder(Id);

            var existingItem = Items.FirstOrDefault(x => x.ProductId == item.ProductId);

            if (existingItem is null)
                throw new DomainException("OrderItem not found");

            _orderItems.Remove(existingItem);
            _orderItems.Add(item);

            CalculateTotal();
        }

        public void SetQuantity(OrderItem item, int value)
        {
            item.SetQuantity(value);
            UpdateItem(item);
        }

        public bool OrderItemExists(OrderItem item)
        {
            return _orderItems.Any(x => x.ProductId == item.ProductId);
        }

        public void DraftOrder()
        {
            Status = OrderStatus.Draft;
        }

        public void CreateOrder()
        {
            Status = OrderStatus.Started;
        }

        public void PayOrder()
        {
            Status = OrderStatus.Payed;
        }

        public void CancelOrder()
        {
            Status = OrderStatus.Canceled;
        }

        public static class OrderFactory
        {
            public static Order DraftOrderInstance(Guid customerId)
            {
                var order = new Order { CustomerId = customerId };
                order.DraftOrder();

                return order;
            }
        }
    }
}
