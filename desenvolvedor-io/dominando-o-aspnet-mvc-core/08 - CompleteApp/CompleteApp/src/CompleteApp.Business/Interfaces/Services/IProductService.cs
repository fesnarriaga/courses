using CompleteApp.Business.Models;
using System;
using System.Threading.Tasks;

namespace CompleteApp.Business.Interfaces.Services
{
    public interface IProductService
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Remove(Guid id);
    }
}
