using System;
using System.Linq;

namespace DesignPatterns.Facade
{
    public class CreditCardPaymentService : IPaymentService
    {
        private readonly ICreditCardPaymentFacade _creditCardPaymentFacade;

        public CreditCardPaymentService(ICreditCardPaymentFacade creditCardPaymentFacade)
        {
            _creditCardPaymentFacade = creditCardPaymentFacade;
        }

        public Payment ExecutePayment(Order order, Payment payment)
        {
            payment.Amount = order.Products.Sum(x => x.Price);

            Console.WriteLine($"Starting credit card transaction - Total: {payment.Amount:C}");

            if (_creditCardPaymentFacade.ExecutePayment(order, payment))
            {
                payment.Status = "Credit card payed";
                return payment;
            }

            payment.Status = "Credit card refused";
            return payment;
        }
    }
}
