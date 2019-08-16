using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Order = DistripackAPI.Controllers.ApiModels.Order;

namespace DistripackAPI.Services.Impl
{
    public class OrderService : Service, IOrderService
    {
        public OrderService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<OrderService> logger)
            : base(mapper, unitOfWork, logger) { }

        public async Task<Order> Create(CreateOrder apiOrder)
        {
            var client = await unitOfWork.Clients.Get(apiOrder.ClientId.Value);
            if (client == null)
                throw new Exception($"El cliente {apiOrder.ClientId} no existe");

            var order = new Models.Order(apiOrder);
            var orderEntry = unitOfWork.Orders.Add(order);

            //if the client doesn't have a checkingAccount, should be created 
            var account = await unitOfWork.CheckingAccounts.Find(a => a.ClientId == client.Id);
            if (account == null)
            {
                account = new Models.CheckingAccount(client.Id, 0);
                unitOfWork.CheckingAccounts.Add(account);
            }

            await unitOfWork.Complete();

            var orderDb = await unitOfWork.Orders.GetWithSku(orderEntry.Entity.Id);
            return mapper.Map<Order>(orderDb);
        }

        public async Task<Order> Modify(UpdateOrder apiOrder)
        {
            var order = await unitOfWork.Orders.GetWithSku(apiOrder.Id.Value);
            if (order == null)
            {
                logger.LogWarning($"La orden {apiOrder.Id.Value} no existe");
                return null;
            }

            order.Modify(apiOrder);
            await unitOfWork.Complete();

            order = await unitOfWork.Orders.GetWithSku(apiOrder.Id.Value);
            return mapper.Map<Order>(order);
        }

        public async Task<ICollection<Order>> Print(IList<int> orderIds)
        {
            var orders = await unitOfWork.Orders.FindAllWithSkus(orderIds);
            foreach (var o in orders)
                Print(o);

            await unitOfWork.Complete();
            return mapper.Map<List<Order>>(orders);
        }

        public async Task<ICollection<Order>> Deliver(IList<int> orderIds)
        {
            var orders = await unitOfWork.Orders.FindAllWithClientAccount(orderIds);
            foreach (var o in orders)
            {
                if (o.Client.CheckingAccount == null)
                    throw new Exception($"El cliente {o.ClientId} no tiene cuenta corriente");

                //when order is delivered, a Receipt transaction is created
                var transaction = o.Deliver();
                unitOfWork.Transactions.Add(transaction);
            }


            await unitOfWork.Complete();
            return mapper.Map<IList<Order>>(orders);
        }


        public async Task<ICollection<int>> Delete(IList<int> orderIds)
        {
            var orders = await unitOfWork.Orders.FindAllWithSkus(orderIds);
            // todo: delete setting deleteDate, not removing from DB
            foreach (var o in orders)
                Delete(o);

            await unitOfWork.Complete();
            return orderIds;
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

        public async Task<ICollection<Order>> GetLatestDelivered()
        {
            var orders = await unitOfWork.Orders.GetLatestDelivered();
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
