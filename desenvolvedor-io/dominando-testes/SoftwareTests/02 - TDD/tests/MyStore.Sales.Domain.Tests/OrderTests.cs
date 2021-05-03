﻿using System;
using System.Linq;
using Xunit;

namespace MyStore.Sales.Domain.Tests
{
    public class OrderTests
    {
        [Fact(DisplayName = "Add OrderItem New Order")]
        [Trait("Category", "Order Tests")]
        public void AddOrderItem_NewOrder_ShouldUpdateTotal()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var orderItem = new OrderItem(Guid.NewGuid(), "Test Product", 100M, 2);

            // Act
            order.AddOrderItem(orderItem);

            // Assert
            Assert.Equal(200M, order.Total);
        }

        [Fact(DisplayName = "Add OrderItem Existing OrderItem")]
        [Trait("Category", "Order Tests")]
        public void AddOrderItem_ExistingOrderItem_ShouldIncrementQuantityAndSumValues()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var orderItem = new OrderItem(productId, "Test Product", 100M, 2);
            order.AddOrderItem(orderItem);

            var anotherOrderItem = new OrderItem(productId, "Test Product", 100M, 1);

            // Act
            order.AddOrderItem(anotherOrderItem);

            // Assert
            Assert.Equal(300, order.Total);
            Assert.Equal(1, order.OrderItems.Count);
            Assert.Equal(3, order.OrderItems.FirstOrDefault(x => x.ProductId == productId)?.Quantity);
        }
    }
}
