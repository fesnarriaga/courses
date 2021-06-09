using System;

namespace DesignPatterns.Composite
{
    public class DomainMessage : IMessage
    {
        public string Name { get; set; }

        public DomainMessage(string name)
        {
            Name = name;
        }

        public void ShowMessages(int hyphens)
        {
            Console.WriteLine($"{new string('-', hyphens)} {Name}");
        }
    }
}
