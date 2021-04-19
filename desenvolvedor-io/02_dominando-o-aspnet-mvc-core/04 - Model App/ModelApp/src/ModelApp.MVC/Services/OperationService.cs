using System;

namespace ModelApp.MVC.Services
{
    public class OperationService
    {
        public IOperationTransient Transient { get; }
        public IOperationScoped Scoped { get; }
        public IOperationSingleton Singleton { get; }
        public IOperationSingletonInstance SingletonInstance { get; }

        public OperationService(
            IOperationTransient transient,
            IOperationScoped scoped,
            IOperationSingleton singleton,
            IOperationSingletonInstance singletonInstance)
        {
            Transient = transient;
            Scoped = scoped;
            Singleton = singleton;
            SingletonInstance = singletonInstance;
        }
    }

    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton, IOperationSingletonInstance

    {
        public Guid Id { get; }

        public Operation() : this(Guid.NewGuid()) { }

        public Operation(Guid id)
        {
            Id = id;
        }
    }

    public interface IOperationSingletonInstance : IOperation { }

    public interface IOperationSingleton : IOperation { }

    public interface IOperationScoped : IOperation { }

    public interface IOperationTransient : IOperation { }

    public interface IOperation
    {
        Guid Id { get; }
    }
}
