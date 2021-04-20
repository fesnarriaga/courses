using Features.Customers;
using System;

namespace Features.Tests
{
    public class CustomerTestsFixture : IDisposable
    {
        public Customer ValidCustomerFactory()
        {
            return new Customer(
                Guid.NewGuid(),
                "Felipe",
                "Esnarriaga",
                DateTime.Now.AddYears(-30),
                "email@server.com",
                true,
                DateTime.Now);
        }

        public Customer InvalidCustomerFactory()
        {
            return new Customer(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                "email@server.com",
                true,
                DateTime.Now);
        }

        public void Dispose() { }
    }
}
