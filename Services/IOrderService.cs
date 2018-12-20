
using DistripackAPI.Controllers.ApiModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Services
{
    public interface IOrderService
    {
        Task<Order> Create(CreateOrder apiOrder);

        Task<Order> Update(UpdateOrder order);

        Task PrintAsync(List<int> orders);

        Task<ICollection<Order>> GetAllCreated();

        Task<ICollection<Order>> GetAllPendings();
    }
}