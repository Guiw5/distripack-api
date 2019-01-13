
using DistripackAPI.Controllers.ApiModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Services
{
    public interface IOrderService
    {
        Task<Order> Create(CreateOrder apiOrder);

        Task<Order> Modify(UpdateOrder order);

        Task Print(List<int> orders);

        Task Deliver(List<int> orders);

        Task Delete(List<int> orders);

        Task<ICollection<Order>> GetAllCreated();

        Task<ICollection<Order>> GetAllPendings();

        Task<ICollection<Order>> GetAllDelivered();
    }
}