using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Features.Tests
{
    [Collection(nameof(CustomerAutoMockerCollection))]
    public class CustomerFluentAssertionTests
    {
        private readonly CustomerAutoMockerFixture _customerAutoMockerFixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public CustomerFluentAssertionTests(
            CustomerAutoMockerFixture customerAutoMockerFixture,
            ITestOutputHelper testOutputHelper)
        {
            _customerAutoMockerFixture = customerAutoMockerFixture;
            _testOutputHelper = testOutputHelper;
        }

        [Fact(DisplayName = "Add Valid Customer")]
        [Trait("Customer FluentAssertions", "Customer FluentAssertions Tests")]
        public void Customer_NewCustomer_ShouldBeSuccess()
        {
            // Arrange
            var customer = _customerAutoMockerFixture.ValidCustomerFactory();

            // Act
            var result = customer.IsValid();

            // Assert
            result.Should().BeTrue();
            customer.ValidationResult.Errors.Should().HaveCount(0);
        }

        [Fact(DisplayName = "Add Invalid Customer")]
        [Trait("Customer FluentAssertions", "Customer FluentAssertions Tests")]
        public void Customer_NewCustomer_ShouldFail()
        {
            // Arrange
            var customer = _customerAutoMockerFixture.InvalidCustomerFactory();

            // Act
            var result = customer.IsValid();

            // Assert
            result.Should().BeFalse();
            customer.ValidationResult.Errors.Should()
                .HaveCountGreaterOrEqualTo(1, "should have validation errors");

            _testOutputHelper.WriteLine($"{customer.ValidationResult.Errors.Count} errors found in this validation");
        }
    }
}
