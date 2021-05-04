using MyStore.Core.Exceptions;
using System;
using Xunit;

namespace MyStore.Sales.Domain.Tests
{
    public class OrderItemTests
    {
        [Fact(DisplayName = "Create OrderItem with less than min units")]
        [Trait("Category", "OrderItem Tests")]
        public void New_LessThanMinUnits_ShouldThrowException()
        {
            // Arrange
            var productId = Guid.NewGuid();

            // Act

            // Assert
            Assert.Throws<DomainException>(() => new OrderItem(productId, "any_name", 1M, Order.MinItemsPerOrder - 1));
        }
    }
}
