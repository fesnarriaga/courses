using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;

namespace NerdStore.Core.DomainObjects.Entities
{
    public abstract class Entity
    {
        private List<Event> _events;

        public Guid Id { get; set; }

        public IReadOnlyCollection<Event> Events => _events?.AsReadOnly();

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public void AddEvent(Event eventObj)
        {
            _events ??= new List<Event>();
            _events.Add(eventObj);
        }

        public void RemoveEvent(Event eventObj)
        {
            _events?.Remove(eventObj);
        }

        public void ClearEvents()
        {
            _events?.Clear();
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo))
                return true;

            return compareTo is not null && Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
