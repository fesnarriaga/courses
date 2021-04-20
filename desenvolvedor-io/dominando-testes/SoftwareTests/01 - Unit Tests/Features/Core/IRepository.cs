using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Features.Core
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(Guid id);

        int Commit();
    }
}
