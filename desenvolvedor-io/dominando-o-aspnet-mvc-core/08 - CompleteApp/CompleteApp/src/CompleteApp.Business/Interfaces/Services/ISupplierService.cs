using CompleteApp.Business.Models;
using System;
using System.Threading.Tasks;

namespace CompleteApp.Business.Interfaces.Services
{
    public interface ISupplierService : IDisposable
    {
        Task Add(Supplier supplier);
        Task Update(Supplier supplier);
        Task Remove(Guid id);

        Task UpdateAddress(Address address);
    }
}
