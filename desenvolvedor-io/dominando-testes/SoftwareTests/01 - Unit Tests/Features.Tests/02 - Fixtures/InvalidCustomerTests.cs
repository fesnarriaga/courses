using Xunit;

namespace Features.Tests
{
    [Collection(nameof(CustomerCollection))]
    public class InvalidCustomerTests
    {
        private readonly CustomerTestsFixture _customerTestsFixture;

        public InvalidCustomerTests(CustomerTestsFixture customerTestsFixture)
        {
            _customerTestsFixture = customerTestsFixture;
        }

        [Fact(DisplayName = "Invalid Customer")]
        [Trait("Customer ", "Customer Fixture Tests")]
        public void Customer_NewCustomer_MustBeInvalid()
        {
            // Arrange
            var customer = _customerTestsFixture.InvalidCustomerFactory();

            // Act
            var result = customer.IsValid();

            // Assert
            Assert.False(result);
            Assert.NotEmpty(customer.ValidationResult.Errors);
        }
    }
}
