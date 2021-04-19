using CompleteApp.Business.Interfaces;
using CompleteApp.Business.Models;
using CompleteApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using CompleteApp.Business.Interfaces.Repositories;

namespace CompleteApp.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(CompleteAppContext context) : base(context) { }

        public async Task<Address> GetSupplierAddress(Guid supplierId)
        {
            return await _context.Addresses
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.SupplierId == supplierId);
        }
    }
}
