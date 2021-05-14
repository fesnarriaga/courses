using MyStore.Core.Exceptions;
using System;
using System.Linq;
using Xunit;

namespace MyStore.Sales.Domain.Tests
{
    public class OrderTests
    {
        [Fact(DisplayName = "Add OrderItem New Order")]
        [Trait("Category", "Sales Order Tests")]
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
        [Trait("Category", "Sales Order Tests")]
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

        [Fact(DisplayName = "Add OrderItem with more than max units")]
        [Trait("Category", "Sales Order Tests")]
        public void AddOrderItem_MoreThanMaxUnits_ShouldThrowException()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var orderItem = new OrderItem(productId, "any_name", 1M, Order.MaxItemsPerOrder + 1);
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());

            // Act

            // Assert
            Assert.Throws<DomainException>(() => order.AddOrderItem(orderItem));
        }

        [Fact(DisplayName = "Add OrderItem with more than max units from existing item")]
        [Trait("Category", "Sales Order Tests")]
        public void AddOrderItem_MoreThanMaxUnitsOnExistingItem_ShouldThrowException()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var orderItem = new OrderItem(productId, "any_name", 1M, Order.MaxItemsPerOrder);
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());

            // Act
            order.AddOrderItem(orderItem);

            // Assert
            Assert.Throws<DomainException>(() => order.AddOrderItem(orderItem));
        }

        [Fact(DisplayName = "Update OrderItem Nonexistent")]
        [Trait("Category", "Sales Order Tests")]
        public void UpdateOrderItem_OrderItemNotInList_ShouldReturnException()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var orderItem = new OrderItem(Guid.NewGuid(), "Test", 100, 5);

            // Act

            // Assert
            Assert.Throws<DomainException>(() => order.UpdateOrderItem(orderItem));
        }

        [Fact(DisplayName = "Update Valid OrderItem")]
        [Trait("Category", "Sales Order Tests")]
        public void UpdateOrderItem_ValidOrderItem_ShouldUpdateQuantity()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productId = Guid.NewGuid();
            var orderItem = new OrderItem(productId, "Test", 100, 2);
            order.AddOrderItem(orderItem);
            var updatedQuantity = 5;
            var updatedOrderItem = new OrderItem(productId, "Test", 100, updatedQuantity);

            // Act
            order.UpdateOrderItem(updatedOrderItem);

            // Assert
            Assert.Equal(updatedQuantity, order.OrderItems.FirstOrDefault(x => x.ProductId == productId)?.Quantity);
        }

        [Fact(DisplayName = "Update OrderItem Validate Total")]
        [Trait("Category", "Sales Order Tests")]
        public void UpdateOrderItem_OrderWithDistinctItems_ShouldUpdateTotal()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productId = Guid.NewGuid();
            var orderItemOne = new OrderItem(new Guid(), "Test One", 10, 2);
            var orderItemTwo = new OrderItem(productId, "Test Two", 20, 3);
            order.AddOrderItem(orderItemOne);
            order.AddOrderItem(orderItemTwo);

            var updatedOrderItem = new OrderItem(productId, "Test Two", 20, 5);
            var total = orderItemOne.ProductPrice * orderItemOne.Quantity +
                              updatedOrderItem.ProductPrice * updatedOrderItem.Quantity;

            // Act
            order.UpdateOrderItem(updatedOrderItem);

            // Assert
            Assert.Equal(total, order.Total);
        }

        [Fact(DisplayName = "Update OrderItem Validate Max Quantity")]
        [Trait("Category", "Sales Order Tests")]
        public void UpdateOrderItem_OrderItemQuantityGreaterThanMax_ShouldReturnException()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productId = Guid.NewGuid();
            var orderItem = new OrderItem(productId, "Test One", 10, 2);
            order.AddOrderItem(orderItem);

            var updatedOrderItem = new OrderItem(productId, "Test Two", 20, Order.MaxItemsPerOrder + 1);

            // Act

            // Assert
            Assert.Throws<DomainException>(() => order.UpdateOrderItem(updatedOrderItem));
        }

        [Fact(DisplayName = "Remove Nonexistent OrderItem")]
        [Trait("Category", "Sales Order Tests")]
        public void RemoveOrderItem_NonExistentOrderItem_ShouldReturnException()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var orderItem = new OrderItem(Guid.NewGuid(), "Test One", 10, 2);

            // Act

            // Assert
            Assert.Throws<DomainException>(() => order.RemoveOrderItem(orderItem));
        }

        [Fact(DisplayName = "Remove OrderItem and Recalculates Order")]
        [Trait("Category", "Sales Order Tests")]
        public void RemoveOrderItem_RemoveOrderItem_ShouldUpdateOrderTotal()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productId = Guid.NewGuid();
            var orderItem = new OrderItem(Guid.NewGuid(), "Test One", 10, 2);
            var orderItemToRemove = new OrderItem(productId, "Test Two", 10, 2);
            order.AddOrderItem(orderItem);
            order.AddOrderItem(orderItemToRemove);
            var totalOrder = orderItem.ProductPrice * orderItem.Quantity;

            // Act
            order.RemoveOrderItem(orderItemToRemove);

            // Assert
            Assert.Equal(totalOrder, order.Total);
        }
    }
}
