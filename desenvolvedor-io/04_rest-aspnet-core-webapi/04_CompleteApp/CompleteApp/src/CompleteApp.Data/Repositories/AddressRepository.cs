using CompleteApp.Business.Interfaces.Repositories;
using CompleteApp.Business.Models;
using CompleteApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CompleteApp.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<Address> GetAddressBySupplier(Guid supplierId)
        {
            return await DbContext.Addresses.AsNoTracking().FirstOrDefaultAsync(x => x.SupplierId == supplierId);
        }
    }
}
