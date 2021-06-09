namespace DesignPatterns.Facade
{
    public interface IPayPalService
    {
        string GetPayPalServiceKey(string apiKey, string encryptionKey);
        string GetCreditCardHashKey(string serviceKey, string creditCard);
        bool CommitTransaction(string creditCardHashKey, string orderId, decimal amount);
    }
}
