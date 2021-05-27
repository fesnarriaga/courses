using System;

namespace DesignPatterns.ObservablePattern
{
    // Concrete Observer
    public class Observer : IObserver
    {
        public string Name { get; }

        public Observer(string name)
        {
            Name = name;
        }

        public void Notify(Investment investment)
        {
            Console.WriteLine($"Notifying {Name}: {investment.Symbol} changed to {investment.Price:C}");
        }
    }
}
