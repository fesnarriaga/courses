using MediatR;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.IntegrationEvents;
using NerdStore.Sales.Application.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Sales.Application.Events
{
    public class OrderEventHandler :
        INotificationHandler<DraftOrderStartedEvent>,
        INotificationHandler<OrderCreatedEvent>,
        INotificationHandler<OrderUpdatedEvent>,
        INotificationHandler<OrderItemAddedEvent>,
        INotificationHandler<OrderItemUpdatedEvent>,
        INotificationHandler<OrderItemRemovedEvent>,
        INotificationHandler<VoucherAppliedEvent>,
        INotificationHandler<OrderPaymentApprovedEvent>,
        INotificationHandler<OrderPaymentRefusedEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public OrderEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public Task Handle(DraftOrderStartedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderItemAddedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderItemUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderItemRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(VoucherAppliedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public async Task Handle(StockDecreaseFailedEvent notification, CancellationToken cancellationToken)
        {
            await _mediatorHandler.SendCommand(
                new CancelOrderProcessCommand(notification.CustomerId, notification.OrderId));
        }

        public async Task Handle(OrderPaymentApprovedEvent notification, CancellationToken cancellationToken)
        {
            await _mediatorHandler.SendCommand(new PayOrderCommand(notification.CustomerId, notification.OrderId));
        }

        public async Task Handle(OrderPaymentRefusedEvent notification, CancellationToken cancellationToken)
        {
            await _mediatorHandler.SendCommand(new CancelOrderProcessAndRollbackStockCommand(notification.CustomerId, notification.OrderId));
        }
    }
}
