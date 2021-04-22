using Bogus;
using Bogus.DataSets;
using Features.Customers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Features.Tests
{
    public class CustomerBogusTestsFixture : IDisposable
    {

        public IEnumerable<Customer> ValidCustomersFactory(int amount, bool isActive)
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var customers = new Faker<Customer>("pt_BR")
                .CustomInstantiator(x => new Customer(
                    Guid.NewGuid(),
                    x.Name.FirstName(gender),
                    x.Name.LastName(gender),
                    x.Date.Past(80, DateTime.Now.AddYears(-18)),
                    "",
                    isActive,
                    DateTime.Now))
                .RuleFor(c => c.Email, (x, c) =>
                    x.Internet.Email(c.Name.ToLower(), c.LastName.ToLower()));

            return customers.Generate(amount);
        }

        public Customer ValidCustomerFactory()
        {
            return ValidCustomersFactory(1, true).FirstOrDefault();
        }

        public IEnumerable<Customer> ValidRandomCustomersFactory()
        {
            var customers = new List<Customer>();

            customers.AddRange(ValidCustomersFactory(50, true).ToList());
            customers.AddRange(ValidCustomersFactory(50, false).ToList());

            return customers;
        }

        public Customer InvalidCustomerFactory()
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var customer = new Faker<Customer>("pt_BR").CustomInstantiator(x => new Customer(
                Guid.NewGuid(),
                x.Name.FirstName(gender),
                x.Name.LastName(gender),
                x.Date.Past(1, DateTime.Now.AddYears(1)),
                "",
                false,
                DateTime.Now));

            return customer;
        }

        public void Dispose() { }
    }
}
