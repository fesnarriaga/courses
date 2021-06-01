using NerdStore.Catalog.Domain.Entities;
using NerdStore.Catalog.Domain.Events;
using NerdStore.Catalog.Domain.Repositories;
using NerdStore.Catalog.Domain.Services;
using NerdStore.Core.Mediator;
using System;
using System.Threading.Tasks;

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

        public async Task<bool> DecreaseStock(Guid productId, int amount)
        {
            var product = await _productRepository.GetById(productId);

            if (product == null)
                return false;

            if (!product.HasStockBalance(amount))
                return false;

            product.DecreaseStock(amount);

            if (product.StockAmount < Product.MinimumStockAmount)
                await _mediatorHandler.RaiseEvent(new MinimumStockAmountEvent(product.Id, product.StockAmount));

            _productRepository.Update(product);

            return await _productRepository.UnitOfWork.Commit();
        }

        public async Task<bool> IncreaseStock(Guid productId, int amount)
        {
            var product = await _productRepository.GetById(productId);

            if (product == null)
                return false;

            product.IncreaseStock(amount);

            _productRepository.Update(product);

            return await _productRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}
