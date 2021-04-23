using CompleteApp.Business.Models;
using System;
using System.Threading.Tasks;

namespace CompleteApp.Business.Interfaces.Services
{
    public interface ISupplierService : IDisposable
    {
        Task<bool> Add(Supplier supplier);
        Task<bool> Update(Supplier supplier);
        Task<bool> Remove(Guid id);

        Task UpdateAddress(Address address);
    }
}
