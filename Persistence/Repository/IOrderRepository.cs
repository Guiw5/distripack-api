using DistripackAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<ICollection<Order>> FindAllWithSkus(IList<int> orderIds);

        Task<ICollection<Order>> GetAllCreated();

        Task<ICollection<Order>> GetAllPendings();

        Task<ICollection<Order>> GetAllDelivered();

        Task<ICollection<Order>> GetLatestDelivered();

        Task<Order> GetWithSku(int id);

        Task<ICollection<Order>> FindAllWithClientAccount(IList<int> orderIds);
    }
}