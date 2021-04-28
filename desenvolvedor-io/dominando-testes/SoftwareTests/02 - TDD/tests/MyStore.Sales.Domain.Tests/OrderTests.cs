using System;
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
            var order = new Order();
            var orderItem = new OrderItem(Guid.NewGuid(), "Test Product", 100M, 2);

            // Act
            order.AddOrderItem(orderItem);

            // Assert
            Assert.Equal(200M, order.Total);
        }
    }
}
