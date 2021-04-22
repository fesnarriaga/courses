using CompleteApp.Business.Models;
using System;
using System.Threading.Tasks;

namespace CompleteApp.Business.Interfaces.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> GetSupplierWithAddress(Guid id);
        Task<Supplier> GetSupplierWithAddressAndProducts(Guid id);
    }
}
