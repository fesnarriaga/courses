using NerdStore.Core.Messages;
using System.Threading.Tasks;

namespace NerdStore.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task RaiseEvent<T>(T eventObj) where T : Event;

        Task<bool> SendCommand<T>(T command) where T : Command;
    }
}
