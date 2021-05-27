using System;

namespace DesignPatterns.Composite
{
    public class InputFormMessage : IMessage
    {
        public string Name { get; set; }

        public InputFormMessage(string name)
        {
            Name = name;
        }

        public void ShowMessages(int hyphens)
        {
            Console.WriteLine($"{new string('-', hyphens)} {Name}");
        }
    }
}
