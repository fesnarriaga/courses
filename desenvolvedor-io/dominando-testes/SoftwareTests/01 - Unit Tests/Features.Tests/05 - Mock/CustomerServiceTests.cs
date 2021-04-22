using Features.Customers;
using MediatR;
using Moq;
using System.Linq;
using System.Threading;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(CustomerBogusCollection))]
    public class CustomerServiceTests
    {
        private readonly CustomerBogusTestsFixture _customerBogusTestsFixture;

        public CustomerServiceTests(CustomerBogusTestsFixture customerBogusTestsFixture)
        {
            _customerBogusTestsFixture = customerBogusTestsFixture;
        }

        [Fact(DisplayName = "Add Customer with Success")]
        [Trait("Customer Mock", "Customer Service Mock Tests")]
        public void CustomerService_Add_MustBeSuccess()
        {
            // Arrange
            var mediator = new Mock<IMediator>();
            var customerRepository = new Mock<ICustomerRepository>();
            var customerService = new CustomerService(mediator.Object, customerRepository.Object);
            var customer = _customerBogusTestsFixture.ValidCustomerFactory();

            // Act
            customerService.Add(customer);

            // Assert
            Assert.True(customer.IsValid());
            customerRepository.Verify(x => x.Add(customer), Times.Once);
            mediator.Verify(x => x.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Fails to Add Customer")]
        [Trait("Customer Mock", "Customer Service Mock Tests")]
        public void CustomerService_Add_MustFail()
        {
            // Arrange
            var mediator = new Mock<IMediator>();
            var customerRepository = new Mock<ICustomerRepository>();
            var customerService = new CustomerService(mediator.Object, customerRepository.Object);
            var customer = _customerBogusTestsFixture.InvalidCustomerFactory();

            // Act
            customerService.Add(customer);

            // Assert
            Assert.False(customer.IsValid());
            customerRepository.Verify(x => x.Add(customer), Times.Never);
            mediator.Verify(x => x.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Get All Active Customers")]
        [Trait("Customer Mock", "Customer Service Mock Tests")]
        public void CustomerService_GetAllActive_ShouldReturnOnlyActiveCustomers()
        {
            // Arrange
            var mediator = new Mock<IMediator>();
            var customerRepository = new Mock<ICustomerRepository>();
            var customerService = new CustomerService(mediator.Object, customerRepository.Object);

            customerRepository
                .Setup(x => x.GetAll())
                .Returns(_customerBogusTestsFixture.ValidRandomCustomersFactory());

            // Act
            var customers = customerService.GetAllActive().ToList();

            // Assert
            Assert.True(customers.Any());
            Assert.DoesNotContain(customers, x => x.IsActive == false);
            customerRepository.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
