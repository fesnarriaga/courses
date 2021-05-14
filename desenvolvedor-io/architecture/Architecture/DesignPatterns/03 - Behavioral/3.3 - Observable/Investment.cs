using System;
using System.Collections.Generic;

namespace DesignPatterns.ObservablePattern
{
    // Subject
    public abstract class Investment
    {
        private decimal _price;
        private readonly List<IObserver> _observers = new();

        public string Symbol { get; set; }

        public decimal Price
        {
            get => _price;
            set
            {
                if (_price == value)
                    return;

                _price = value;

                Notify();
            }
        }

        protected Investment(string symbol, decimal price)
        {
            _price = price;
            Symbol = symbol;
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine($"Observer {observer.Name} is listening {Symbol}");
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"Observer {observer.Name} is not listening {Symbol} anymore");
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Notify(this);
            }

            Console.WriteLine();
        }
    }
}
