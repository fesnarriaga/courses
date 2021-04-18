using CompleteApp.Business.Interfaces.Notifications;
using CompleteApp.Business.Interfaces.Repositories;
using CompleteApp.Business.Interfaces.Services;
using CompleteApp.Business.Models;
using CompleteApp.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace CompleteApp.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(
            INotificator notificator, 
            IProductRepository productRepository) : base(notificator)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            if (!Validate(new ProductValidation(), product))
                return;

            await _productRepository.Create(product);
        }

        public async Task Update(Product product)
        {
            if (!Validate(new ProductValidation(), product))
                return;

            await _productRepository.Update(product);
        }

        public async Task Remove(Guid id)
        {
            await _productRepository.Remove(id);
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}
