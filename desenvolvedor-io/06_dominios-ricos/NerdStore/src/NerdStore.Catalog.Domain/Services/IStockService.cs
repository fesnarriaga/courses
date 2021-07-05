using NerdStore.Core.DomainObjects.Dtos.Order;
using System;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Services
{
    public interface IStockService : IDisposable
    {
        Task<bool> DecreaseStock(Guid productId, int quantity);
        Task<bool> DecreaseStockProductList(ProductList productList);

        Task<bool> IncreaseStock(Guid productId, int quantity);
        Task<bool> IncreaseStockProductList(ProductList productList);
    }
}
