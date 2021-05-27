using System;
using System.Linq;

namespace DesignPatterns.Facade
{
    public class PayPalService : IPayPalService
    {
        public string GetPayPalServiceKey(string apiKey, string encryptionKey)
        {
            return new(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        public string GetCreditCardHashKey(string serviceKey, string creditCard)
        {
            return new(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 10)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        public bool CommitTransaction(string creditCardHashKey, string orderId, decimal amount)
        {
            return new Random().Next(2) == 0;
        }
    }
}
