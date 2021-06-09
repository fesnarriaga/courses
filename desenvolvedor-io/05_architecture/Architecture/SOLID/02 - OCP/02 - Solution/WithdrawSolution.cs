using System;
using System.Linq;

namespace SOLID
{
    public abstract class WithdrawSolution
    {
        public string TransactionNumber { get; set; }

        public abstract string Withdraw(decimal value, string account);

        public string GetTransactionNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();

            TransactionNumber = new string(Enumerable.Repeat(chars, 15)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return TransactionNumber;
        }
    }
}
