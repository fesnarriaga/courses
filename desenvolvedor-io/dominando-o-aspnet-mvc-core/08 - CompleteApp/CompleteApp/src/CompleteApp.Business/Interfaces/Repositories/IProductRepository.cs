using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CompleteApp.Business.Models;

namespace CompleteApp.Business.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsWithSuppliers();

        Task<Product> GetProductWithSupplier(Guid id);

        Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId);
    }
}
