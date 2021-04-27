using Features.Customers;
using FluentAssertions;
using FluentAssertions.Extensions;
using MediatR;
using Moq;
using System.Linq;
using System.Threading;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(CustomerAutoMockerCollection))]
    public class CustomerServicesFluentAssertionTests
    {
        private readonly CustomerAutoMockerFixture _customerAutoMockerFixture;
        private readonly CustomerService _customerService;

        public CustomerServicesFluentAssertionTests(
            CustomerAutoMockerFixture customerAutoMockerFixture)
        {
            _customerAutoMockerFixture = customerAutoMockerFixture;
            _customerService = _customerAutoMockerFixture.CustomerServiceFactory();
        }

        [Fact(DisplayName = "Add Customer with Success")]
        [Trait("Customer FluentAssertions ", "Customer Service FluentAssertions Tests")]
        public void CustomerService_Add_ShouldBeSuccess()
        {
            // Arrange
            var customer = _customerAutoMockerFixture.ValidCustomerFactory();

            // Act
            _customerService.Add(customer);

            // Assert
            customer.IsValid().Should().BeTrue();

            _customerAutoMockerFixture.Mocker.GetMock<ICustomerRepository>()
                .Verify(x => x.Add(customer), Times.Once);

            _customerAutoMockerFixture.Mocker.GetMock<IMediator>()
                .Verify(x => x.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Add Customer with Fail")]
        [Trait("Customer FluentAssertions ", "Customer Service FluentAssertions Tests")]
        public void CustomerService_Add_ShouldFail()
        {
            // Arrange
            var customer = _customerAutoMockerFixture.InvalidCustomerFactory();

            // Act
            _customerService.Add(customer);

            // Assert
            Assert.False(customer.IsValid());

            customer.IsValid().Should().BeFalse("Invalid input");
            customer.ValidationResult.Errors.Should().HaveCountGreaterOrEqualTo(1);

            _customerAutoMockerFixture.Mocker.GetMock<ICustomerRepository>()
                .Verify(x => x.Add(customer), Times.Never);

            _customerAutoMockerFixture.Mocker.GetMock<IMediator>()
                .Verify(x => x.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Get Active Customers")]
        [Trait("Customer FluentAssertions ", "Customer Service FluentAssertions Tests")]
        public void CustomerService_GetAllActive_ShouldReturnOnlyActiveCustomers()
        {
            // Arrange
            _customerAutoMockerFixture.Mocker.GetMock<ICustomerRepository>()
                .Setup(x => x.GetAll())
                .Returns(_customerAutoMockerFixture.RandomValidCustomersFactory());

            // Act
            var customers = _customerService.GetAllActive().ToList();

            // Assert
            customers.Should().HaveCountGreaterOrEqualTo(1).And.OnlyHaveUniqueItems();
            customers.Should().NotContain(x => x.IsActive == false);

            _customerAutoMockerFixture.Mocker.GetMock<ICustomerRepository>()
                .Verify(r => r.GetAll(), Times.Once);

            _customerService.ExecutionTimeOf(x => x.GetAllActive())
                .Should().BeLessOrEqualTo(50.Milliseconds(), "it is executed thousand times per second");
        }
    }
}
