using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Services.Impl
{
    public class OrderService : Service, IOrderService
    {
        public OrderService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<OrderService> logger)
            : base(mapper, unitOfWork, logger) { }

        public async Task<Order> Create(CreateOrder apiOrder)
        {
            var client = await unitOfWork.Clients.Get(apiOrder.ClientId);
            if (client == null)
            {
                logger.LogWarning($"El cliente {apiOrder.ClientId} no existe");
                throw new Exception($"El cliente {apiOrder.ClientId} no existe");
            }

            var order = new Models.Order(apiOrder);
            var orderEntry = unitOfWork.Orders.Add(order);
            await unitOfWork.Complete();

            return mapper.Map<Order>(orderEntry.Entity);
        }

        public async Task<Order> Modify(UpdateOrder apiOrder)
        {
            var order = await unitOfWork.Orders.Get(apiOrder.Id);
            if (order == null)
            {
                logger.LogWarning($"La orden {apiOrder.Id} no existe");
                throw new Exception($"La orden {apiOrder.Id} no existe");
            }

            order.Modify(apiOrder);
            await unitOfWork.Complete();
            return mapper.Map<Order>(order);
        }

        public async Task Print(List<int> orderIds)
        {
            var orders = await unitOfWork.Orders.FindAll(o => orderIds.Contains(o.Id));
            foreach (var o in orders)
                Print(o);


            await unitOfWork.Complete();
        }

        public async Task Deliver(List<int> orderIds)
        {
            var orders = await unitOfWork.Orders.FindAll(o => orderIds.Contains(o.Id));
            foreach (var o in orders)
                Deliver(o);
            await unitOfWork.Complete();
        }


        public async Task Delete(List<int> orderIds)
        {
            var orders = await unitOfWork.Orders.FindAll(o => orderIds.Contains(o.Id));
            // todo: delete setting deleteDate, not removing from DB
            foreach (var o in orders)
                Delete(o);

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

        public async Task<ICollection<Order>> GetAllDelivered()
        {
            var orders = await unitOfWork.Orders.GetAllDelivered();
            var apiOrders = mapper.Map<IList<Order>>(orders);
            return apiOrders;
        }

        private void Print(Models.Order o)
        {
            try
            {
                o.Print();
            }
            catch (Exception e)
            {
                logger.LogWarning(e.Message);
            }
        }

        private void Deliver(Models.Order o)
        {
            try
            {
                o.Deliver();
            }
            catch (Exception e)
            {
                logger.LogWarning(e.Message);
            }
        }

        private void Delete(Models.Order o)
        {
            try
            {
                o.Delete();
            }
            catch (Exception e)
            {
                logger.LogWarning(e.Message);
            }
        }

    }
}
