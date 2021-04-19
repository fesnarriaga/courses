using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CompleteApp.Business.Models;

namespace CompleteApp.Business.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> GetById(Guid id);

        Task<List<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Remove(Guid id);

        Task<int> SaveChanges();
    }
}
