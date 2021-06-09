using NerdStore.Catalog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(Guid id);
        Task<IEnumerable<ProductViewModel>> GetByCategory(string code);

        Task Add(ProductViewModel productViewModel);
        Task Update(ProductViewModel productViewModel);

        // Category
        Task<IEnumerable<CategoryViewModel>> GetCategories();

        // Stock
        Task<ProductViewModel> DecreaseStock(Guid productId, int amount);
        Task<ProductViewModel> IncreaseStock(Guid productId, int amount);
    }
}
