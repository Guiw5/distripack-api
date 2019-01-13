using DistripackAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<ICollection<Order>> GetAllWithSkus();

        Task<ICollection<Order>> GetAllCreated();

        Task<ICollection<Order>> GetAllPendings();

        Task<ICollection<Order>> GetAllDelivered();
    }
}