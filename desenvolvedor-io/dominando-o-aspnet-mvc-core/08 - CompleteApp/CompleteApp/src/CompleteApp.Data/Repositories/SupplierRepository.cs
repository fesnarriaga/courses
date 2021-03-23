using CompleteApp.Business.Interfaces;
using CompleteApp.Business.Models;
using CompleteApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CompleteApp.Data.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(CompleteAppContext context) : base(context) { }

        public async Task<Supplier> GetSupplierWithAddress(Guid id)
        {
            return await _context.Suppliers
                .AsNoTracking()
                .Include(a => a.Address)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Supplier> GetSupplierWithAddressAndProducts(Guid id)
        {
            return await _context.Suppliers
                .AsNoTracking()
                .Include(a => a.Address)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
