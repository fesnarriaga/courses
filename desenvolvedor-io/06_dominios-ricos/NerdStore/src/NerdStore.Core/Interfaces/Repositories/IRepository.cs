using NerdStore.Core.DomainObjects.Interfaces;
using NerdStore.Core.Interfaces.UnitOfWork;
using System;

namespace NerdStore.Core.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
