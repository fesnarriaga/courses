using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Features.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IMediator _mediator;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMediator mediator, ICustomerRepository customerRepository)
        {
            _mediator = mediator;
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllActive()
        {
            return _customerRepository.GetAll().Where(x => x.IsActive);
        }

        public void Add(Customer customer)
        {
            if (!customer.IsValid())
                return;

            _customerRepository.Add(customer);

            _mediator.Publish(
                new CustomerEmailNotification("admin@me.com", customer.Email, "Add", "Welcome"));
        }

        public void Update(Customer customer)
        {
            if (!customer.IsValid())
                return;

            _customerRepository.Update(customer);

            _mediator.Publish(
                new CustomerEmailNotification("admin@me.com", customer.Email, "Update", "Check"));
        }

        public void Remove(Customer customer)
        {
            _customerRepository.Remove(customer.Id);

            _mediator.Publish(
                new CustomerEmailNotification("admin@me.com", customer.Email, "Remove", "Bye"));
        }

        public void Disable(Customer customer)
        {
            if (!customer.IsValid())
                return;

            customer.Disable();

            _customerRepository.Update(customer);

            _mediator.Publish(
                new CustomerEmailNotification("admin@me.com", customer.Email, "Disable", "Lock"));
        }

        public void Dispose()
        {
            _customerRepository?.Dispose();
        }
    }
}
