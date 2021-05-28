using System.Threading.Tasks;

namespace NerdStore.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
