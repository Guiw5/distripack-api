using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Services.Impl
{
    public class OrderService : Service, IOrderService
    {
        public OrderService(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork) { }

        public async Task<Order> Create(CreateOrder apiOrder)
        {
            var client = await unitOfWork.Clients.Get(apiOrder.ClientId);
            if (client == null)
                throw new Exception($"El cliente {apiOrder.ClientId } no existe");

            var order = new Models.Order(apiOrder);
            var orderEntry = unitOfWork.Orders.Add(order);
            await unitOfWork.Complete();

            return mapper.Map<Order>(orderEntry.Entity);
        }

        public async Task<Order> Update(UpdateOrder apiOrder)
        {
            var order = await unitOfWork.Orders.Get(apiOrder.Id);
            order.Update(apiOrder.Items, apiOrder.DeliveryDate);
            await unitOfWork.Complete();
            return mapper.Map<Order>(order);
        }

        public async Task PrintAsync(List<int> orderIds)
        {
            var orders = await unitOfWork.Orders.FindAll(o => orderIds.Contains(o.Id));
            foreach (var o in orders)
                o.Print();
            await unitOfWork.Complete();
        }

        public async Task<ICollection<Order>> GetAllCreated()
        {
            var orders = await unitOfWork.Orders.GetAllCreated();
            var apiOrders = mapper.Map<IList<Order>>(orders);
            return apiOrders;
        }

        public async Task<ICollection<Order>> GetAllPendings()
        {
            var orders = await unitOfWork.Orders.GetAllPendings();
            var apiOrders = mapper.Map<IList<Order>>(orders);
            return apiOrders;
        }
    }
}
