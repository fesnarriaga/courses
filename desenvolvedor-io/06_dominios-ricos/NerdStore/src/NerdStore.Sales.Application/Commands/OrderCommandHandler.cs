using MediatR;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages;
using NerdStore.Sales.Domain.Entities;
using NerdStore.Sales.Domain.Interfaces.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Sales.Application.Commands
{
    public class OrderCommandHandler :
        IRequestHandler<AddOrderItemCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(IMediatorHandler mediatorHandler, IOrderRepository orderRepository)
        {
            _mediatorHandler = mediatorHandler;
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(request))
                return false;

            var order = await _orderRepository.GetDraftOrderByCustomerId(request.CustomerId);
            var orderItem = new OrderItem(request.ProductId, request.ProductName, request.Quantity, request.Price);

            if (order == null)
            {
                order = Order.OrderFactory.DraftOrderInstance(request.CustomerId);
                order.AddItem(orderItem);

                _orderRepository.Add(order);
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
            }

            return await _orderRepository.UnitOfWork.Commit();
        }

        private bool ValidateCommand(Command command)
        {
            if (command.IsValid())
                return true;

            foreach (var error in command.ValidationResult.Errors)
            {
                // Raise error event
            }

            return false;
        }
    }
}
