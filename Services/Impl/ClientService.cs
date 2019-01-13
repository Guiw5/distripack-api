using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Helper;
using DistripackAPI.Persistence;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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

        public async Task<Client> Create(CreateClient apiClient)
        {
            var client = mapper.Map<Models.Client>(apiClient);
            var clientEntry = unitOfWork.Clients.Add(client);
            await unitOfWork.Complete();

            emailSender.SendClientRegistrationEmail(clientEntry.Entity.Mail, clientEntry.Entity.Nick);
            return mapper.Map<Client>(clientEntry.Entity);

        }


        public async Task Modify(UpdateClient apiClient)
        {
            var client = await unitOfWork.Clients.Find(c => c.Mail == apiClient.Email);

            if (client != null)
                client.Update(apiClient);
            else
            {
                logger.LogWarning($"No existe el cliente con Email: {apiClient.Email}");
                client = new Models.Client(apiClient);
                unitOfWork.Clients.Add(client);

            }
            await unitOfWork.Complete();
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
