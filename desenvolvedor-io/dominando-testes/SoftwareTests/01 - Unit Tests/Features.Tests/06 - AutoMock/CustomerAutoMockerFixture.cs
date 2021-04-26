using Bogus;
using Bogus.DataSets;
using Features.Customers;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Features.Tests
{
    public class CustomerAutoMockerFixture : IDisposable
    {
        public AutoMocker Mocker;
        public CustomerService CustomerService;

        public Customer ValidCustomerFactory()
        {
            return ValidCustomersFactory(1, true).FirstOrDefault();
        }

        public IEnumerable<Customer> RandomValidCustomersFactory()
        {
            var customers = new List<Customer>();

            customers.AddRange(ValidCustomersFactory(50, true));
            customers.AddRange(ValidCustomersFactory(50, false));

            return customers;
        }

        public IEnumerable<Customer> ValidCustomersFactory(int amount, bool isActive)
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var customerConfiguration = new Faker<Customer>("pt_BR")
                .CustomInstantiator(x => new Customer(
                    Guid.NewGuid(),
                    x.Name.FirstName(gender),
                    x.Name.LastName(gender),
                    x.Date.Past(80, DateTime.Now.AddYears(-18)),
                    string.Empty,
                    isActive,
                    DateTime.Now))
                .RuleFor(c => c.Email, (x, c) =>
                    x.Internet.Email(c.Name.ToLower(), c.LastName.ToLower()));

            return customerConfiguration.Generate(amount);
        }

        public Customer InvalidCustomerFactory()
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var customer = new Faker<Customer>("pt_BR")
                .CustomInstantiator(x => new Customer(
                    Guid.NewGuid(),
                    x.Name.FirstName(gender),
                    x.Name.LastName(gender),
                    x.Date.Past(1, DateTime.Now).AddYears(1),
                    string.Empty,
                    false,
                    DateTime.Now));

            return customer;
        }

        public CustomerService CustomerServiceFactory()
        {
            Mocker = new AutoMocker();
            CustomerService = Mocker.CreateInstance<CustomerService>();

            return CustomerService;
        }

        public void Dispose() { }
    }
}
