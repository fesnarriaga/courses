using NerdStore.Catalog.Domain.Events;
using NerdStore.Catalog.Domain.Repositories;
using NerdStore.Catalog.Domain.Services;
using NerdStore.Core.DomainObjects.Dtos;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.Notifications;
using System;
using System.Threading.Tasks;
using NerdStore.Core.DomainObjects.Dtos.Order;

namespace NerdStore.Catalog.Service.Services
{
    public class StockService : IStockService
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProductRepository _productRepository;

        public StockService(IMediatorHandler mediatorHandler, IProductRepository productRepository)
        {
            _mediatorHandler = mediatorHandler;
            _productRepository = productRepository;
        }

        public async Task<bool> DecreaseStock(Guid productId, int quantity)
        {
            if (!await DecreaseStockItem(productId, quantity))
                return false;

            return await _productRepository.UnitOfWork.Commit();
        }

        public async Task<bool> DecreaseStockProductList(ProductList productList)
        {
            foreach (var product in productList.Items)
            {
                if (!await DecreaseStock(product.Id, product.Quantity))
                    return false;
            }

            return await _productRepository.UnitOfWork.Commit();
        }

        public async Task<bool> IncreaseStock(Guid productId, int quantity)
        {
            if (!await IncreaseStockItem(productId, quantity))
                return false;

            return await _productRepository.UnitOfWork.Commit();
        }

        public async Task<bool> IncreaseStockProductList(ProductList productList)
        {
            foreach (var product in productList.Items)
            {
                if (!await IncreaseStock(product.Id, product.Quantity))
                    return false;
            }

            return await _productRepository.UnitOfWork.Commit();
        }

        private async Task<bool> DecreaseStockItem(Guid productId, int quantity)
        {
            var product = await _productRepository.GetById(productId);

            if (product is null)
                return false;

            if (!product.HasStockBalance(quantity))
            {
                var message = $"{product.Id} - {product.Name} => unavailable stock";
                await _mediatorHandler.PublishNotification(new DomainNotification("Stock", message));
                return false;
            }

            product.DecreaseStock(quantity);

            if (product.StockAmount < 10)
                await _mediatorHandler.RaiseDomainEvent(new MinimumStockAmountEvent(
                    product.Id, product.StockAmount));

            _productRepository.Update(product);
            return true;
        }

        private async Task<bool> IncreaseStockItem(Guid productId, int quantity)
        {
            var product = await _productRepository.GetById(productId);

            if (product is null)
                return false;

            product.IncreaseStock(quantity);

            _productRepository.Update(product);
            return true;
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}
