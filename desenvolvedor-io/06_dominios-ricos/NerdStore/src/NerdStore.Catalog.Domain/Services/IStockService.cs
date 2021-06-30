using NerdStore.Core.DomainObjects.Dtos;
using System;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Services
{
    public interface IStockService : IDisposable
    {
        Task<bool> DecreaseStock(Guid productId, int quantity);
        Task<bool> DecreaseStockList(ProductList productList);

        Task<bool> IncreaseStock(Guid productId, int quantity);
        Task<bool> IncreaseStockList(ProductList productList);
    }
}
