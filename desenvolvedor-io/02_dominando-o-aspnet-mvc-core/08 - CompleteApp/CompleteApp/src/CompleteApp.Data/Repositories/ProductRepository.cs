using CompleteApp.Business.Interfaces;
using CompleteApp.Business.Models;
using CompleteApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompleteApp.Business.Interfaces.Repositories;

namespace CompleteApp.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CompleteAppContext context) : base(context) { }
        public async Task<IEnumerable<Product>> GetProductsWithSuppliers()
        {
            return await _context.Products
                .AsNoTracking()
                .Include(s => s.Supplier)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<Product> GetProductWithSupplier(Guid id)
        {
            return await _context.Products
                .AsNoTracking()
                .Include(s => s.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId)
        {
            return await Find(p => p.SupplierId == supplierId);
        }
    }
}
