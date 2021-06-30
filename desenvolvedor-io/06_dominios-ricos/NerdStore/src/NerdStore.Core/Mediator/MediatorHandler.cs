using MediatR;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.DomainEvents;
using NerdStore.Core.Messages.Notifications;
using System.Threading.Tasks;

namespace NerdStore.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task RaiseEvent<T>(T eventObj) where T : Event
        {
            await _mediator.Publish(eventObj);
        }

        public async Task<bool> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task PublishNotification<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);
        }

        public async Task RaiseDomainEvent<T>(T eventObj) where T : DomainEvent
        {
            await _mediator.Publish(eventObj);
        }
    }
}
