using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace entityFrameworkTest.Data.Repositories
{
    public interface IReadRepository<TEntity, in TKey> : IDisposable where TEntity : class
    {
        TEntity GetById(TKey id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null);
    }
}
