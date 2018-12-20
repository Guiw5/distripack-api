using DistripackAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository.Impl
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly ApplicationDbContext Context;

        protected Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        protected virtual IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null,
            int? skip = null, int? take = null)
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<T> query = Context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }



        public virtual async Task<IEnumerable<T>> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null, int? skip = null, int? take = null)
        {
            return await GetQueryable(null, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null,
            int? skip = null, int? take = null)
        {
            return await GetQueryable(filter, orderBy, includeProperties, skip, take).ToListAsync();
        }

        public virtual async Task<T> Find(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            return await GetQueryable(filter, null, includeProperties).SingleOrDefaultAsync();
        }

        public virtual async Task<T> First(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            return await GetQueryable(filter, orderBy, includeProperties).FirstOrDefaultAsync();
        }

        public virtual async Task<int> Count(Expression<Func<T, bool>> filter = null)
        {
            return await GetQueryable(filter).CountAsync();
        }

        public virtual Task<bool> Exists(Expression<Func<T, bool>> filter = null)
        {
            return GetQueryable(filter).AnyAsync();
        }

        public virtual async Task<T> Get(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual EntityEntry<T> Add(T entity)
        {
            return Context.Set<T>().Add(entity);
        }

        //public virtual void Update(T entity)
        //{
        //    Context.Set<T>().Update(entity);
        //}

        //public virtual void Delete(int id)
        //{
        //    T entity = Context.Set<T>().Find(id);
        //    Delete(entity);
        //}

        //public virtual void Delete(T entity)
        //{
        //    var dbSet = Context.Set<T>();
        //    if (Context.Entry(entity).State == EntityState.Detached)
        //    {
        //        dbSet.Attach(entity);
        //    }
        //    dbSet.Remove(entity);
        //}
    }

}
