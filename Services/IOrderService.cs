
using DistripackAPI.Controllers.ApiModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Services
{
    public interface IOrderService
    {
        Task<Order> Create(CreateOrder apiOrder);

        Task<Order> Modify(UpdateOrder order);

        Task<ICollection<Order>> Print(IList<int> orders);

        Task<ICollection<Order>> Deliver(IList<int> orders);

        Task<ICollection<int>> Delete(IList<int> orders);

        Task<ICollection<Order>> GetAllCreated();

        Task<ICollection<Order>> GetAllPendings();

        Task<ICollection<Order>> GetAllDelivered();

        Task<ICollection<Order>> GetLatestDelivered();
    }
}