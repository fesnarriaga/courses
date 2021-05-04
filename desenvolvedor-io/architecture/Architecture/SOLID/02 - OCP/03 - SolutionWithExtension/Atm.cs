using System;

namespace SOLID
{
    public class Atm
    {
        private static void MenuOptions()
        {
            Console.Clear();

            Console.WriteLine("SOLID ATM");
            Console.WriteLine("Choose a option: \n");

            Console.WriteLine("1 - Checking account");
            Console.WriteLine("2 - Stock account");
            Console.WriteLine("2 - Saving account");
        }

        private static WithdrawExtension WithdrawData()
        {
            Console.WriteLine("\n.................................\n");

            Console.WriteLine("Account number: ");
            var accountNumber = Console.ReadLine();

            Console.WriteLine("Value: ");
            var value = Convert.ToDecimal(Console.ReadLine());

            var withdrawAccount = new WithdrawExtension
            {
                AccountNumber = accountNumber,
                Value = value
            };

            return withdrawAccount;
        }

        private static void TransactionResult(string result)
        {
            Console.WriteLine($"\n Success! Transaction # : {result}\n");
        }

        public static void Options()
        {
            MenuOptions();

            var option = Console.ReadKey();
            var result = string.Empty;

            var account = WithdrawData();

            switch (option.KeyChar)
            {
                case '1':
                    Console.WriteLine("Operating in Checking Account");
                    result = account.WithdrawCheckingAccount();
                    break;

                case '2':
                    Console.WriteLine("Operating in Stock Account");
                    result = account.WithdrawStockAccount();
                    break;

                case '3':
                    Console.WriteLine("Operating in Savings Account");
                    result = account.WithdrawSavingsAccount();
                    break;
            }

            TransactionResult(result);
        }
    }
}
