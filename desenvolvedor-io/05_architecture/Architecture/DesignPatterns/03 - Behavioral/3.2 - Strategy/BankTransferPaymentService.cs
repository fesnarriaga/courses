using DesignPatterns.Facade;
using System;
using System.Linq;

namespace DesignPatterns.Strategy
{
    public class BankTransferPaymentService : IPaymentService
    {
        private readonly IBankTransferPaymentFacade _bankTransferPaymentFacade;

        public BankTransferPaymentService(IBankTransferPaymentFacade bankTransferPaymentFacade)
        {
            _bankTransferPaymentFacade = bankTransferPaymentFacade;
        }

        public Payment ExecutePayment(Order order, Payment payment)
        {
            payment.Amount = order.Products.Sum(x => x.Price);

            Console.WriteLine($"Starting bank transfer payment - Total: {payment.Amount:C}");
            payment.BankTransferNumber = _bankTransferPaymentFacade.MakeTransfer();
            payment.Status = "Bank transfer paid";

            return payment;
        }
    }
}
