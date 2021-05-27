using System;

namespace DesignPatterns.ObservablePattern
{
    public static class ExecuteObserver
    {
        public static void Execute()
        {
            var jeff = new Observer("Jeff");
            var mary = new Observer("Mary");
            var bill = new Observer("Bill");

            var amazon = new Stock("AMZ3", NextDecimal());
            var microsoft = new Stock("MSF4", NextDecimal());

            amazon.Subscribe(jeff);
            amazon.Subscribe(mary);

            microsoft.Subscribe(mary);
            microsoft.Subscribe(bill);

            Console.WriteLine("\n----------------------------\n");

            for (var i = 0; i < 5; i++)
            {
                amazon.Price = NextDecimal();
                microsoft.Price = NextDecimal();

                switch (i)
                {
                    case 1:
                        amazon.Unsubscribe(jeff);
                        break;
                    case 3:
                        amazon.Subscribe(jeff);
                        break;
                }
            }
        }

        public static decimal NextDecimal()
        {
            var random = new Random();

            var randomResult = random.Next(141421, 314160);

            return randomResult / 100000M;
        }
    }
}
