using CompleteApp.Business.Interfaces.Repositories;
using CompleteApp.Business.Models;
using CompleteApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CompleteApp.Data.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<Supplier> GetSupplierWithAddress(Guid id)
        {
            return await DbContext.Suppliers
                .AsNoTracking()
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Supplier> GetSupplierWithAddressAndProducts(Guid id)
        {
            return await DbContext.Suppliers
                .AsNoTracking()
                .Include(x => x.Address)
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
