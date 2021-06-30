using NerdStore.Core.Messages;
using NerdStore.Core.Messages.DomainEvents;
using NerdStore.Core.Messages.Notifications;
using System.Threading.Tasks;

namespace NerdStore.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task RaiseEvent<T>(T eventObj) where T : Event;

        Task<bool> SendCommand<T>(T command) where T : Command;

        Task PublishNotification<T>(T notification) where T : DomainNotification;

        Task RaiseDomainEvent<T>(T eventObj) where T : DomainEvent;
    }
}
