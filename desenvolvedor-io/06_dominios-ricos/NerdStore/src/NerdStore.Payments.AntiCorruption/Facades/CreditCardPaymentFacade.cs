using NerdStore.Payments.AntiCorruption.Configurations;
using NerdStore.Payments.AntiCorruption.Interfaces.PayPal;
using NerdStore.Payments.Business.Entities;
using NerdStore.Payments.Business.Enums;
using NerdStore.Payments.Business.Interfaces.Facades;
using NerdStore.Payments.Business.ViewModels;

namespace NerdStore.Payments.AntiCorruption.Facades
{
    public class CreditCardPaymentFacade : ICreditCardPaymentFacade
    {
        private readonly IConfigurationManager _configurationManager;
        private readonly IPayPalGateway _payPalGateway;

        public CreditCardPaymentFacade(IConfigurationManager configurationManager, IPayPalGateway payPalGateway)
        {
            _configurationManager = configurationManager;
            _payPalGateway = payPalGateway;
        }

        public Transaction Pay(Order order, Payment payment)
        {
            var apiKey = _configurationManager.GetValue("apiKey");
            var encryptionKey = _configurationManager.GetValue("encryptionKey");

            var serviceKey = _payPalGateway.GetServiceKey(apiKey, encryptionKey);
            var creditCardHash = _payPalGateway.GetCreditCardHash(serviceKey, payment.CardNumber);

            var paymentResult = _payPalGateway.CommitTransaction(creditCardHash, order.Id.ToString(), payment.Total);

            // TODO: Simulating gateway result
            var transaction = new Transaction
            {
                OrderId = order.Id,
                PaymentId = payment.Id,
                Total = order.Total
            };

            if (paymentResult)
            {
                transaction.Status = TransactionStatus.Payed;
                return transaction;
            }

            transaction.Status = TransactionStatus.Refused;
            return transaction;
        }
    }
}
