using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository
{
    public interface IRepository<T> where T : class
    {

        Task<T> Get(int id);

        Task<ICollection<T>> GetAll();

        Task<ICollection<T>> Find(Expression<Func<T, bool>> expression);

        Task Add(T entity);

        void Delete(T entity);
    }
}
