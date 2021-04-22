using Xunit;

namespace Features.Tests
{
    [Collection(nameof(CustomerBogusCollection))]
    public class CustomerBogusTests
    {
        private readonly CustomerBogusTestsFixture _customerBogusTestsFixture;

        public CustomerBogusTests(CustomerBogusTestsFixture customerBogusTestsFixture)
        {
            _customerBogusTestsFixture = customerBogusTestsFixture;
        }

        [Fact(DisplayName = "Valid Customer")]
        [Trait("Customer Bogus", "Customer Bogus Tests")]
        public void Customer_NewCustomer_MustBeValid()
        {
            // Arrange
            var customer = _customerBogusTestsFixture.ValidCustomerFactory();

            // Act
            var result = customer.IsValid();

            // Assert
            Assert.True(result);
            Assert.Empty(customer.ValidationResult.Errors);
        }

        [Fact(DisplayName = "Invalid Customer")]
        [Trait("Customer Bogus", "Customer Bogus Tests")]
        public void Customer_NewCustomer_MustBeInvalid()
        {
            // Arrange
            var customer = _customerBogusTestsFixture.InvalidCustomerFactory();

            // Act
            var result = customer.IsValid();

            // Assert
            Assert.False(result);
            Assert.NotEmpty(customer.ValidationResult.Errors);
        }
    }
}
