using Xunit;

namespace Features.Tests
{
    [Collection(nameof(CustomerCollection))]
    public class ValidCustomerTests
    {
        private readonly CustomerTestsFixture _customerTestsFixture;

        public ValidCustomerTests(CustomerTestsFixture customerTestsFixture)
        {
            _customerTestsFixture = customerTestsFixture;
        }

        [Fact(DisplayName = "Valid Customer")]
        [Trait("Customer ", "Customer Fixture Tests")]
        public void Customer_NewCustomer_MustBeValid()
        {
            // Arrange
            var customer = _customerTestsFixture.ValidCustomerFactory();

            // Act
            var result = customer.IsValid();

            // Assert
            Assert.True(result);
            Assert.Empty(customer.ValidationResult.Errors);
        }
    }
}
