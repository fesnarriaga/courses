﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Sales.Application.Events
{
    public class OrderEventHandler :
        INotificationHandler<DraftOrderStartedEvent>,
        INotificationHandler<OrderUpdatedEvent>,
        INotificationHandler<OrderItemAddedEvent>
    {
        public Task Handle(DraftOrderStartedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderItemAddedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
