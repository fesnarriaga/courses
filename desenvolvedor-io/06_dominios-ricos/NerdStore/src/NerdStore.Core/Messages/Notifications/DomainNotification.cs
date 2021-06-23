using MediatR;
using System;

namespace NerdStore.Core.Messages.Notifications
{
    public class DomainNotification : Message, INotification
    {
        public Guid Id { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }
        public DateTime Timestamp { get; private set; }

        public DomainNotification(string key, string value)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
            Timestamp = DateTime.Now;
        }
    }
}
