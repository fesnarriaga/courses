using DesignPatterns.Facade;
using System;
using System.Linq;

namespace DesignPatterns.Strategy
{
    public class BankSlipPaymentService : IPaymentService
    {
        private readonly IBankSlipPaymentFacade _bankSlipPaymentFacade;

        public BankSlipPaymentService(IBankSlipPaymentFacade bankSlipPaymentFacade)
        {
            _bankSlipPaymentFacade = bankSlipPaymentFacade;
        }

        public Payment ExecutePayment(Order order, Payment payment)
        {
            payment.Amount = order.Products.Sum(x => x.Price);

            Console.WriteLine($"Starting bank slip payment - Total: {payment.Amount:C}");
            payment.BankSlipNumber = _bankSlipPaymentFacade.CreateBankSlip();
            payment.Status = "Pending";

            return payment;
        }
    }
}
