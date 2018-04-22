using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace LookTechnoCMS.Data.Infrastructure
{

    public interface IEntityService<TEntity>

    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity Find(int id);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        bool Edit(TEntity entity);
        bool CanDeleteRecord(TEntity entity);
        void Update(TEntity entity);
    }
}
