using CompleteApp.Business.Interfaces.Repositories;
using CompleteApp.Business.Models;
using CompleteApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompleteApp.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<Product> GetProductWithSupplier(Guid id)
        {
            return await DbContext.Products
                .AsNoTracking()
                .Include(x => x.Supplier)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsWithSupplier()
        {
            return await DbContext.Products
                .AsNoTracking()
                .Include(x => x.Supplier)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId)
        {
            return await Find(x => x.SupplierId == supplierId);
        }
    }
}
