using MediatR;
using NerdStore.Core.Messages;
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
    }
}
