using System;

namespace DemoDI.Cases
{
    public class OperationService
    {
        public IOperationTransient Transient { get; set; }
        public IOperationScoped Scoped { get; set; }
        public IOperationSingleton Singleton { get; set; }
        public IOperationSingletonInstance SingletonInstance { get; set; }

        public OperationService(IOperationTransient transient,
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

    public class Operation : IOperationTransient,
                             IOperationScoped,
                             IOperationSingleton,
                             IOperationSingletonInstance
    {
        public Guid OperationId { get; private set; }

        public Operation(Guid operationId)
        {
            OperationId = operationId;
        }

        public Operation() : this(Guid.NewGuid()) { }
    }

    public interface IOperationTransient : IOperation
    {
    }

    public interface IOperationScoped : IOperation
    {
    }

    public interface IOperationSingleton : IOperation
    {
    }

    public interface IOperationSingletonInstance : IOperation
    {
    }

    public interface IOperation
    {
        Guid OperationId { get; }
    }
}
