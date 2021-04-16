using System;
using System.Threading.Tasks;
using CompleteApp.Business.Models;

namespace CompleteApp.Business.Interfaces.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetSupplierAddress(Guid supplierId);
    }
}
