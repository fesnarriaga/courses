namespace DesignPatterns.Facade
{
    public class Payment
    {
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }

        public string CreditCardNumber { get; set; }
        public string BankSlipNumber { get; set; }
        public string BankTransferNumber { get; set; }
    }
}
