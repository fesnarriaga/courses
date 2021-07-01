namespace NerdStore.Payments.AntiCorruption.Interfaces.PayPal
{
    public interface IPayPalGateway
    {
        string GetServiceKey(string apiKey, string encryptionKey);
        string GetCreditCardHash(string serviceKey, string creditCard);
        bool CommitTransaction(string creditCardHash, string orderId, decimal total);
    }
}
