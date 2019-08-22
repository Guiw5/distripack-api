using DistripackAPI.Controllers.ApiModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Services
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetAll();
    }
}