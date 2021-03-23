using CompleteApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompleteApp.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId);

        Task<IEnumerable<Product>> GetAllProductsAndSuppliers();

        Task<Product> GetProductSupplier(Guid id);
    }
}
