using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Helper;
using DistripackAPI.Persistence;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistripackAPI.Services.Impl
{
    public class ClientService : Service, IClientService
    {
        private readonly IEmailSender emailSender;

        public ClientService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ClientService> logger, IEmailSender emailSender) : base(mapper, unitOfWork, logger)
        {
            this.emailSender = emailSender;
        }

        public async Task<FullClient> GetClient(int id)
        {
            var client = await unitOfWork.Clients.Get(id);
            var pendingAmount = await unitOfWork.Clients.GetBalance(id);
            if (client == null)
            {
                logger.LogWarning($"No existe el cliente con Id: {id}");
                return null;
            }

            return mapper.Map<FullClient>(client);
        }


        public async Task<ClientHistory> GetClientHistory(int clientId)
        {
            var orders = await unitOfWork.Clients.FindHistory(clientId);

            var clientHistory = new ClientHistory
            {
                Orders = mapper.Map<ICollection<Order>>(orders),
                TotalAmount = orders.Sum(o => o.Subtotal)
            };

            return clientHistory;
        }

        public async Task<Client> Create(CreateClient apiClient)
        {
            var client = mapper.Map<Models.Client>(apiClient);
            var clientEntry = unitOfWork.Clients.Add(client);
            await unitOfWork.Complete();

            emailSender.SendClientRegistrationEmail(clientEntry.Entity.Email, clientEntry.Entity.Nick);
            return mapper.Map<Client>(clientEntry.Entity);

        }


        public async Task<Client> Modify(UpdateClient apiClient)
        {
            var client = await unitOfWork.Clients.Find(c => c.Email == apiClient.Email);

            if (client == null)
            {
                logger.LogWarning($"No existe el cliente con Email: {apiClient.Email}");
                return null;
            }
            else
            {
                client.Update(apiClient);
                await unitOfWork.Complete();
            }


            return mapper.Map<Client>(client);
        }


        public async Task<ICollection<Client>> GetAll()
        {
            var clientes = await unitOfWork.Clients.GetAll();
            return mapper.Map<IList<Client>>(clientes);
        }

        public async Task<ICollection<FullClient>> GetAllFull()
        {
            var clientes = await unitOfWork.Clients.GetAll();
            return mapper.Map<IList<FullClient>>(clientes);
        }

    }
}
