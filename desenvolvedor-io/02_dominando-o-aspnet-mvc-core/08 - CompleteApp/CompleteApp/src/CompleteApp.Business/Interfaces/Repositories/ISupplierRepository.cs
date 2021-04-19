using System;
using System.Threading.Tasks;
using CompleteApp.Business.Models;

namespace CompleteApp.Business.Interfaces.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> GetSupplierWithAddress(Guid id);

        Task<Supplier> GetSupplierWithAddressAndProducts(Guid id);
    }
}
