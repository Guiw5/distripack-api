using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository.Impl
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        protected Repository(DbContext context)
        {
            Context = context;
        }

        public virtual async Task<T> Get(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public virtual async Task<ICollection<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().Where(expression).ToListAsync();
        }

        public virtual async Task<EntityEntry<T>> Add(T entity)
        {
            return await Context.Set<T>().AddAsync(entity);
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
    }

    //public class Entity
    //{
    //    public int Id { get; set; }
    //}
}
