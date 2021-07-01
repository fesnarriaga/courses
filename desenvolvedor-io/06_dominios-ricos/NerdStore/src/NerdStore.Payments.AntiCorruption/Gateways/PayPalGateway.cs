using NerdStore.Payments.AntiCorruption.Interfaces.PayPal;
using System;
using System.Linq;

namespace NerdStore.Payments.AntiCorruption.Gateways
{
    public class PayPalGateway : IPayPalGateway
    {
        public string GetServiceKey(string apiKey, string encryptionKey)
        {
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 20)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        public string GetCreditCardHash(string serviceKey, string creditCard)
        {
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 30)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        public bool CommitTransaction(string creditCardHash, string orderId, decimal total)
        {
            return new Random().Next(2) == 0;
        }
    }
}
