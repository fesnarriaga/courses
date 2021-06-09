namespace DesignPatterns.Facade
{
    public class CreditCardPaymentFacade : ICreditCardPaymentFacade
    {
        private readonly IPayPalService _payPalService;
        private readonly IConfigurationManager _configurationManager;

        public CreditCardPaymentFacade(IPayPalService payPalService, IConfigurationManager configurationManager)
        {
            _payPalService = payPalService;
            _configurationManager = configurationManager;
        }

        public bool ExecutePayment(Order order, Payment payment)
        {
            var apiKey = _configurationManager.GetValue("apiKey");
            var encryptionKey = _configurationManager.GetValue("encryptionKey");

            var serviceKey = _payPalService.GetPayPalServiceKey(apiKey, encryptionKey);
            var creditCardHashKey = _payPalService.GetCreditCardHashKey(serviceKey, payment.CreditCardNumber);

            var transactionResult =
                _payPalService.CommitTransaction(creditCardHashKey, order.Id.ToString(), order.Total);

            return transactionResult;
        }
    }
}
