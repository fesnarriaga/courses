using System;

namespace DemoDI.Cases
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public interface ICustomerRepository
    {
        void Add(Customer customer);
    }

    public class CustomerRepository : ICustomerRepository
    {
        public void Add(Customer customer)
        {
            // Do something
        }
    }

    public interface ICustomerServices
    {
        void Add(Customer customer);
    }

    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Add(Customer customer)
        {
            _customerRepository.Add(customer);
        }
    }
}
