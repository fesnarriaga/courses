using DesignPatterns.Facade;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Strategy
{
    public class ExecuteStrategy
    {
        public static void Execute()
        {
            var products = new List<Product>
            {
                new Product { Name = "Shirt", Price = new Random().Next(500) },
                new Product { Name = "Shoes", Price = new Random().Next(500) },
                new Product { Name = "Pants", Price = new Random().Next(500) }
            };

            var order = new Order { Id = Guid.NewGuid(), Products = products };

            var creditCardPayment = new Payment
            {
                PaymentType = PaymentType.CreditCard,
                CreditCardNumber = "5555 3333 7777 1111"
            };

            var bankSlipPayment = new Payment
            {
                PaymentType = PaymentType.BankSlip,
            };

            var bankTransferPayment = new Payment
            {
                PaymentType = PaymentType.BankTransfer
            };

            #region Easy Way

            var creditCardOrder = new OrderService(
                new CreditCardPaymentService(
                    new CreditCardPaymentFacade(new PayPalService(), new ConfigurationManager())));

            var creditCardPaymentResult = creditCardOrder.ExecutePayment(order, creditCardPayment);
            Console.WriteLine(creditCardPaymentResult.Status);

            Console.WriteLine("\n--------------------------------------------------------\n");

            var bankSlipOrder = new OrderService(
                new BankSlipPaymentService(
                    new BankSlipPaymentFacade()));

            var bankSlipPaymentResult = bankSlipOrder.ExecutePayment(order, bankSlipPayment);
            Console.WriteLine(bankSlipPaymentResult.Status);

            Console.WriteLine("\n--------------------------------------------------------\n");

            var bankTransferOrder = new OrderService(
                new BankTransferPaymentService(
                    new BankTransferPaymentFacade()));

            var bankTransferPaymentResult = bankTransferOrder.ExecutePayment(order, bankTransferPayment);
            Console.WriteLine(bankTransferPaymentResult.Status);

            Console.WriteLine("\n--------------------------------------------------------\n");

            #endregion

            #region Elegant Way Using Factories

            var creditCardOrderFactory = new OrderService(PaymentFactory.CreatePaymentService(creditCardPayment.PaymentType));
            var creditCardPaymentFactoryResult = creditCardOrderFactory.ExecutePayment(order, creditCardPayment);
            Console.WriteLine(creditCardPaymentFactoryResult.Status);

            Console.WriteLine("\n--------------------------------------------------------\n");

            var bankSlipOrderFactory = new OrderService(PaymentFactory.CreatePaymentService(bankSlipPayment.PaymentType));
            var bankSlipPaymentFactoryResult = bankSlipOrderFactory.ExecutePayment(order, bankSlipPayment);
            Console.WriteLine(bankSlipPaymentFactoryResult.Status);

            Console.WriteLine("\n--------------------------------------------------------\n");

            var bankTransferOrderFactory = new OrderService(PaymentFactory.CreatePaymentService(bankTransferPayment.PaymentType));
            var bankTransferPaymentFactoryResult = bankTransferOrderFactory.ExecutePayment(order, bankTransferPayment);
            Console.WriteLine(bankTransferPaymentFactoryResult.Status);

            #endregion
        }
    }
}
