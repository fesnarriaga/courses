using System;
using System.Collections.Generic;

namespace DesignPatterns.Facade
{
    public class ExecuteFacade
    {
        public static void Execute()
        {
            var products = new List<Product>
            {
                new Product{ Name = "Shoes", Price = new Random().Next(500) },
                new Product{ Name = "Shirt", Price = new Random().Next(500) },
                new Product{ Name = "Pants", Price = new Random().Next(500) }
            };

            var order = new Order
            {
                Id = Guid.NewGuid(),
                Products = products
            };

            var payment = new Payment { CreditCardNumber = "5555 3333 7777 9999" };

            // DI
            var payPalService = new PayPalService();
            var configurationManager = new ConfigurationManager();
            var creditCardPaymentFacade = new CreditCardPaymentFacade(payPalService, configurationManager);
            var creditCardPaymentService = new CreditCardPaymentService(creditCardPaymentFacade);

            var executePaymentResult = creditCardPaymentService.ExecutePayment(order, payment);

            Console.WriteLine(executePaymentResult.Status);
        }
    }
}
