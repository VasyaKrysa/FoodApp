using EatingApp.Core.Abstractions.Repositories;
using System;
using EatingApp.Core.Entities;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EatingApp.DAL
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity<int>
    {
        private readonly FoodApiContext _context;

        public BaseRepository(FoodApiContext context)
        {
            _context = context;
        }

        public virtual TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        
            return entity;
        }

        public virtual void Delete(int id)
        {
            var entity= _context.Set<TEntity>().Find(id);
            if (entity != null)
                _context.Set<TEntity>().Remove(entity);
            else
                throw new Exception("Not found");
           
        }

        public virtual void Edit(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual IQueryable<TEntity> List()
        {
            return _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>()
              .Where(predicate);
        }
    }
}
