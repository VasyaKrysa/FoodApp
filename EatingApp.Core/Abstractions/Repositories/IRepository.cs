using EatingApp.Core.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EatingApp.Core.Abstractions.Repositories
{
    public interface IRepository<TEntity> where TEntity: IEntity<int>
    {
        TEntity GetById(int id);
        IQueryable<TEntity> List();
        IQueryable<TEntity> List(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        void Delete(int id);
        void Edit(TEntity entity);
    }
}
