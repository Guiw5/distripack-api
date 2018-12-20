using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Helper;
using DistripackAPI.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Services.Impl
{
    public class ClientService : Service, IClientService
    {
        private readonly IEmailSender emailSender;

        public ClientService(IMapper mapper, IUnitOfWork unitOfWork, IEmailSender emailSender) : base(mapper, unitOfWork)
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

        public async Task<ICollection<Client>> GetAll()
        {
            var clientes = await unitOfWork.Clients.GetAll();
            emailSender.SendClientRegistrationEmail("guiw_5@hotmail.com", "La Casa de Juan");
            return mapper.Map<IList<Client>>(clientes);
        }

    }
}
