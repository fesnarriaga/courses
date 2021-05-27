using DesignPatterns.Facade;
using System;

namespace DesignPatterns.Strategy
{
    public class PaymentFactory
    {
        public static IPaymentService CreatePaymentService(PaymentType paymentType)
        {
            return paymentType switch
            {
                PaymentType.CreditCard => new CreditCardPaymentService(
                    new CreditCardPaymentFacade(new PayPalService(), new ConfigurationManager())),

                PaymentType.BankSlip => new BankSlipPaymentService(new BankSlipPaymentFacade()),

                PaymentType.BankTransfer => new BankTransferPaymentService(new BankTransferPaymentFacade()),

                _ => throw new ApplicationException("Unknown payment type")
            };
        }
    }
}
