using System;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Services
{
    public interface IStockService : IDisposable
    {
        Task<bool> DecreaseStock(Guid productId, int amount);
        Task<bool> IncreaseStock(Guid productId, int amount);
    }
}
