using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Composite
{
    public class Message : IMessage, IEnumerable<IMessage>
    {
        private readonly List<IMessage> _messages = new List<IMessage>();

        public string Name { get; set; }

        public Message(string name)
        {
            Name = name;
        }

        public void Add(IMessage childMessage)
        {
            _messages.Add(childMessage);
        }

        public void Remove(IMessage childMessage)
        {
            _messages.Remove(childMessage);
        }

        public IMessage GetChild(int index)
        {
            return _messages[index];
        }

        public IMessage GetChild(string name)
        {
            return _messages.First(x => x.Name == name);
        }

        public IEnumerable<IMessage> GetList()
        {
            return _messages;
        }

        public void ShowMessages(int hyphens)
        {
            Console.WriteLine($"{new string('-', hyphens)} {Name}");

            foreach (var message in _messages)
            {
                message.ShowMessages(hyphens + 1);
            }
        }

        public IEnumerator<IMessage> GetEnumerator()
        {
            return ((IEnumerable<IMessage>)_messages).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
