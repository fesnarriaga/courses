using Features.Customers;
using MediatR;
using Moq;
using Moq.AutoMock;
using System.Linq;
using System.Threading;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(CustomerBogusCollection))]
    public class CustomerServiceAutoMockerTests
    {
        private readonly CustomerBogusTestsFixture _customerBogusTestsFixture;

        public CustomerServiceAutoMockerTests(CustomerBogusTestsFixture customerBogusTestsFixture)
        {
            _customerBogusTestsFixture = customerBogusTestsFixture;
        }

        [Fact(DisplayName = "Add Customer with Success")]
        [Trait("Customer Bogus ", "Customer Bogus AutoMock Tests")]
        public void CustomerService_Add_ShouldBeSuccess()
        {
            // Arrange
            var mocker = new AutoMocker();
            var customerService = mocker.CreateInstance<CustomerService>();
            var customer = _customerBogusTestsFixture.ValidCustomerFactory();

            // Act
            customerService.Add(customer);

            // Assert
            Assert.True(customer.IsValid());
            mocker.GetMock<ICustomerRepository>().Verify(x => x.Add(customer), Times.Once);
            mocker.GetMock<IMediator>().Verify(x => x.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Add Customer with Fail")]
        [Trait("Customer Bogus ", "Customer Bogus AutoMock Tests")]
        public void CustomerService_Add_ShouldFail()
        {
            // Arrange
            var mocker = new AutoMocker();
            var customerService = mocker.CreateInstance<CustomerService>();
            var customer = _customerBogusTestsFixture.InvalidCustomerFactory();

            // Act
            customerService.Add(customer);

            // Assert
            Assert.False(customer.IsValid());
            mocker.GetMock<ICustomerRepository>().Verify(x => x.Add(customer), Times.Never);
            mocker.GetMock<IMediator>().Verify(x => x.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Get Active Customers")]
        [Trait("Customer Bogus ", "Customer Bogus AutoMock Tests")]
        public void CustomerService_GetAllActive_ShouldReturnOnlyActiveCustomers()
        {
            // Arrange
            var mocker = new AutoMocker();
            var customerService = mocker.CreateInstance<CustomerService>();

            mocker.GetMock<ICustomerRepository>()
                .Setup(x => x.GetAll())
                .Returns(_customerBogusTestsFixture.ValidRandomCustomersFactory());

            // Act
            var customers = customerService.GetAllActive().ToList();

            // Assert
            Assert.True(customers.Any());
            Assert.DoesNotContain(customers, x => x.IsActive == false);
            mocker.GetMock<ICustomerRepository>().Verify(x => x.GetAll(), Times.Once);
        }
    }
}
