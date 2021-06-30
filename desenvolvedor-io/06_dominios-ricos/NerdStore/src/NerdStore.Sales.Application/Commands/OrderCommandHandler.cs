using MediatR;
using NerdStore.Core.DomainObjects.Dtos;
using NerdStore.Core.Extensions;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.IntegrationEvents;
using NerdStore.Core.Messages.Notifications;
using NerdStore.Sales.Application.Events;
using NerdStore.Sales.Domain.Entities;
using NerdStore.Sales.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Sales.Application.Commands
{
    public class OrderCommandHandler :
        IRequestHandler<CreateOrderCommand, bool>,
        IRequestHandler<AddOrderItemCommand, bool>,
        IRequestHandler<UpdateOrderItemCommand, bool>,
        IRequestHandler<RemoveOrderItemCommand, bool>,
        IRequestHandler<ApplyVoucherCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(IMediatorHandler mediatorHandler, IOrderRepository orderRepository)
        {
            _mediatorHandler = mediatorHandler;
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request))
                return false;

            var order = await _orderRepository.GetDraftOrderByCustomer(request.CustomerId);
            order.CreateOrder();

            var items = new List<ProductListItem>();
            order.Items.ForEach(x => items.Add(new ProductListItem { Id = x.Id, Quantity = x.Quantity }));
            var products = new ProductList { OrderId = order.Id, Items = items };

            order.AddEvent(new OrderCreatedEvent(
                request.CustomerId,
                order.Id,
                order.Total,
                products,
                request.CardName,
                request.CardNumber,
                request.CardExpiresAt,
                request.CardCode));

            _orderRepository.Update(order);
            return await _orderRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request))
                return false;

            var order = await _orderRepository.GetDraftOrderByCustomer(request.CustomerId);
            var orderItem = new OrderItem(request.ProductId, request.ProductName, request.Quantity, request.Price);

            if (order == null)
            {
                order = Order.OrderFactory.DraftOrderInstance(request.CustomerId);
                order.AddItem(orderItem);

                _orderRepository.Add(order);
                order.AddEvent(new DraftOrderStartedEvent(request.CustomerId, order.Id));
            }
            else
            {
                var orderItemExists = order.OrderItemExists(orderItem);
                order.AddItem(orderItem);

                if (orderItemExists)
                {
                    _orderRepository.UpdateOrderItem(
                        order.Items.FirstOrDefault(x => x.ProductId == orderItem.ProductId));
                }
                else
                {
                    _orderRepository.AddOrderItem(orderItem);
                }

                order.AddEvent(new OrderUpdatedEvent(request.CustomerId, order.Id, order.Total));
            }

            order.AddEvent(new OrderItemAddedEvent(
                request.CustomerId,
                order.Id,
                request.ProductId,
                request.ProductName,
                request.Price,
                request.Quantity));

            return await _orderRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request))
                return false;

            var order = await _orderRepository.GetDraftOrderByCustomer(request.CustomerId);

            if (order is null)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification("Order", "Order not found"));
                return false;
            }

            var orderItem = await _orderRepository.GetOrderItemByOrderAndProduct(order.Id, request.ProductId);

            if (!order.OrderItemExists(orderItem))
            {
                await _mediatorHandler.PublishNotification(new DomainNotification("Order", "OrderItem not found"));
                return false;
            }

            order.SetQuantity(orderItem, request.Quantity);
            order.AddEvent(new OrderItemUpdatedEvent(
                request.CustomerId,
                order.Id,
                request.ProductId,
                request.Quantity));

            _orderRepository.UpdateOrderItem(orderItem);
            _orderRepository.Update(order);

            return await _orderRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request))
                return false;

            var order = await _orderRepository.GetDraftOrderByCustomer(request.CustomerId);

            if (order is null)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification("Order", "Order not found"));
                return false;
            }

            var orderItem = await _orderRepository.GetOrderItemByOrderAndProduct(order.Id, request.ProductId);

            if (orderItem != null && !order.OrderItemExists(orderItem))
            {
                await _mediatorHandler.PublishNotification(new DomainNotification("Order", "OrderItem not found"));
                return false;
            }

            order.RemoveItem(orderItem);
            order.AddEvent(new OrderItemRemovedEvent(
                request.CustomerId,
                order.Id,
                request.ProductId));

            _orderRepository.RemoveOrderItem(orderItem);
            _orderRepository.Update(order);

            return await _orderRepository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(ApplyVoucherCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request))
                return false;

            var order = await _orderRepository.GetDraftOrderByCustomer(request.CustomerId);

            if (order is null)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification("Order", "Order not found"));
                return false;
            }

            var voucher = await _orderRepository.GetVoucherByCode(request.VoucherCode);

            if (voucher is null)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification("Order", "Voucher not found"));
                return false;
            }

            var applyVoucher = order.ApplyVoucher(voucher);
            if (!applyVoucher.IsValid)
            {
                foreach (var error in applyVoucher.Errors)
                {
                    await _mediatorHandler.PublishNotification(new DomainNotification(error.ErrorCode,
                        error.ErrorMessage));
                }

                return false;
            }

            order.AddEvent(new VoucherAppliedEvent(request.CustomerId, order.Id, voucher.Id));

            _orderRepository.Update(order);

            return await _orderRepository.UnitOfWork.Commit();
        }

        private bool ValidateCommand(Command command)
        {
            if (command.IsValid())
                return true;

            foreach (var error in command.ValidationResult.Errors)
            {
                _mediatorHandler.PublishNotification(
                    new DomainNotification(command.MessageType, error.ErrorMessage));
            }

            return false;
        }
    }
}
