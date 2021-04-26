using Features.Customers;
using MediatR;
using Moq;
using System.Linq;
using System.Threading;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(CustomerAutoMockerCollection))]
    public class CustomerAutoMockerFixtureTests
    {
        private readonly CustomerAutoMockerFixture _customerAutoMockerFixture;
        private readonly CustomerService _customerService;

        public CustomerAutoMockerFixtureTests(
            CustomerAutoMockerFixture customerAutoMockerFixture)
        {
            _customerAutoMockerFixture = customerAutoMockerFixture;
            _customerService = _customerAutoMockerFixture.CustomerServiceFactory();
        }

        [Fact(DisplayName = "Add Customer with Success")]
        [Trait("Customer AutoMock Fixture", "Customer Service AutoMockFixture Tests")]
        public void CustomerService_Add_ShouldBeSuccess()
        {
            // Arrange
            var customer = _customerAutoMockerFixture.ValidCustomerFactory();

            // Act
            _customerService.Add(customer);

            // Assert
            Assert.True(customer.IsValid());
            _customerAutoMockerFixture.Mocker.GetMock<ICustomerRepository>()
                .Verify(x => x.Add(customer), Times.Once);
            _customerAutoMockerFixture.Mocker.GetMock<IMediator>()
                .Verify(x => x.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Add Customer with Fail")]
        [Trait("Customer AutoMock Fixture", "Customer Service AutoMockFixture Tests")]
        public void CustomerService_Add_ShouldFail()
        {
            // Arrange
            var customer = _customerAutoMockerFixture.InvalidCustomerFactory();

            // Act
            _customerService.Add(customer);

            // Assert
            Assert.False(customer.IsValid());
            _customerAutoMockerFixture.Mocker.GetMock<ICustomerRepository>()
                .Verify(x => x.Add(customer), Times.Never);
            _customerAutoMockerFixture.Mocker.GetMock<IMediator>()
                .Verify(x => x.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Get All Active Customers")]
        [Trait("Customer AutoMock Fixture", "Customer Service AutoMockFixture Tests")]
        public void CustomerService_GetAllActive_ShouldReturnOnlyActiveCustomers()
        {
            // Arrange
            _customerAutoMockerFixture.Mocker.GetMock<ICustomerRepository>()
                .Setup(x => x.GetAll())
                .Returns(_customerAutoMockerFixture.RandomValidCustomersFactory());

            // Act
            var customers = _customerService.GetAllActive().ToList();

            // Assert
            Assert.True(customers.Any());
            Assert.DoesNotContain(customers, x => !x.IsActive);
            _customerAutoMockerFixture.Mocker.GetMock<ICustomerRepository>()
                .Verify(x => x.GetAll(), Times.Once);
        }
    }
}
