using MediatR;
using NerdStore.Catalog.Domain.Repositories;
using NerdStore.Catalog.Domain.Services;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.IntegrationEvents;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Events
{
    public class ProductEventHandler :
        INotificationHandler<MinimumStockAmountEvent>,
        INotificationHandler<OrderCreatedEvent>,
        INotificationHandler<OrderProcessCanceledEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProductRepository _productRepository;
        private readonly IStockService _stockService;

        public ProductEventHandler(
            IMediatorHandler mediatorHandler,
            IProductRepository productRepository,
            IStockService stockService)
        {
            _mediatorHandler = mediatorHandler;
            _productRepository = productRepository;
            _stockService = stockService;
        }

        public async Task Handle(MinimumStockAmountEvent notification, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(notification.AggregateId);

            // Do something
        }

        public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            if (await _stockService.DecreaseStockProductList(notification.ProductList))
            {
                await _mediatorHandler.RaiseEvent(new StockDecreaseSucceedEvent(
                    notification.CustomerId,
                    notification.OrderId,
                    notification.Total,
                    notification.ProductList,
                    notification.CardName,
                    notification.CardNumber,
                    notification.CardExpiresAt,
                    notification.CardCode));
            }
            else
            {
                await _mediatorHandler.RaiseEvent(new StockDecreaseFailedEvent(
                    notification.CustomerId,
                    notification.OrderId));
            }
        }

        public async Task Handle(OrderProcessCanceledEvent notification, CancellationToken cancellationToken)
        {
            await _stockService.IncreaseStockProductList(notification.ProductList);
        }
    }
}
