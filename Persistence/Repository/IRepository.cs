using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository
{
    public interface IRepository { }
    public interface IRepository<T> : IRepository where T : class
    {

        /// <summary>
        ///     Get all entities sortered with includedProperties
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = null, int? skip = null, int? take = null);

        /// <summary>
        ///   Find all entities matching filter, sortered, with includedProperties
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null, int? skip = null, int? take = null);

        /// <summary>
        ///     Find a entity that match filter, with included properties
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<T> Find(Expression<Func<T, bool>> filter = null, string includeProperties = null);

        /// <summary>
        ///     Take first element of sortered list of entities that match filter 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<T> First(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);

        /// <summary>
        ///     Counts number of items that match filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<int> Count(Expression<Func<T, bool>> filter = null);

        /// <summary>
        ///     Check if exists a entity that match filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<bool> Exists(Expression<Func<T, bool>> filter = null);

        /// <summary>
        ///     Get element by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> Get(int id);

        /// <summary>
        ///  Add entity to repository
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        EntityEntry<T> Add(T entity);

        /// <summary>
        /// Update entity to repository
        /// </summary>
        /// <param name="itemDb"></param>
        /// <returns></returns>
        void Update(T entity);

        /// <summary>
        ///  Delete entity by Id
        /// </summary>
        /// <param name="entity"></param>
        void Delete(int id);

        /// <summary>
        ///  Delete entity from repository
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}
