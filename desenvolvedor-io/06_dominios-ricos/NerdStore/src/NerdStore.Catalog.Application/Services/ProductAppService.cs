using AutoMapper;
using NerdStore.Catalog.Application.Interfaces;
using NerdStore.Catalog.Application.ViewModels;
using NerdStore.Catalog.Domain.Entities;
using NerdStore.Catalog.Domain.Repositories;
using NerdStore.Catalog.Domain.Services;
using NerdStore.Core.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IStockService _stockService;
        private readonly IProductRepository _productRepository;

        public ProductAppService(
            IMapper mapper,
            IStockService stockService,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _stockService = stockService;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAll());
        }

        public async Task<ProductViewModel> GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.GetById(id));
        }

        public async Task<IEnumerable<ProductViewModel>> GetByCategory(string code)
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetByCategory(code));
        }

        public async Task Add(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);

            _productRepository.Add(product);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task Update(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);

            _productRepository.Update(product);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(await _productRepository.GetCategories());
        }

        public async Task<ProductViewModel> DecreaseStock(Guid productId, int amount)
        {
            if (!_stockService.DecreaseStock(productId, amount).Result)
                throw new DomainException("Failed to decrease stock");

            return _mapper.Map<ProductViewModel>(await _productRepository.GetById(productId));
        }

        public async Task<ProductViewModel> IncreaseStock(Guid productId, int amount)
        {
            if (!_stockService.IncreaseStock(productId, amount).Result)
                throw new DomainException("Failed to increase stock");

            return _mapper.Map<ProductViewModel>(await _productRepository.GetById(productId));
        }

        public void Dispose()
        {
            _stockService?.Dispose();
            _productRepository?.Dispose();
        }
    }
}
