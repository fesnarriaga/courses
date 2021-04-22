using CompleteApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompleteApp.Business.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductWithSupplier(Guid id);
        Task<IEnumerable<Product>> GetAllProductsWithSupplier();
        Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId);
    }
}
