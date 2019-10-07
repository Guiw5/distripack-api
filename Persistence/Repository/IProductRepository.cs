using DistripackAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithSkus(int id);

        Task<ICollection<Product>> GetAll();

        Task<ICollection<Sku>> GetSkus();
    }
}
