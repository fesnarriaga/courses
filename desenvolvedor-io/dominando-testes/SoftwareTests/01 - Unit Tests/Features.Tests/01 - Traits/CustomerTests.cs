using Features.Customers;
using System;
using Xunit;

namespace Features.Tests
{
    public class CustomerTests
    {
        [Fact(DisplayName = "Valid Customer")]
        [Trait("Customer","New Customer Tests")]
        public void Customer_NewCustomer_MustBeValid()
        {
            // Arrange
            var customer = new Customer(
                Guid.NewGuid(),
                "Felipe",
                "Esnarriaga",
                DateTime.Now.AddYears(-35),
                "email@server.com",
                true,
                DateTime.Now);

            // Act
            var result = customer.IsValid();

            // Assert
            Assert.True(result);
            Assert.Equal(0, customer.ValidationResult.Errors.Count);
            Assert.Empty(customer.ValidationResult.Errors); // Prefer this to validate collections
        }

        [Fact(DisplayName = "Invalid Customer")]
        [Trait("Customer", "New Customer Tests")]
        public void Customer_NewCustomer_MustBeInvalid()
        {
            // Arrange
            var customer = new Customer(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                "email@server.com",
                true,
                DateTime.Now);

            // Act
            var result = customer.IsValid();

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, customer.ValidationResult.Errors.Count);
            Assert.NotEmpty(customer.ValidationResult.Errors); // Prefer this
        }
    }
}
