using DistripackAPI.Controllers.ApiModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Services
{
    public interface IClientService
    {
        Task<Client> Create(CreateClient apiClient);

        Task<ICollection<Client>> GetAll();

        Task<ICollection<FullClient>> GetAllFull();

        Task<Client> Modify(UpdateClient apiClient);

        Task<FullClient> GetClient(int id);

        Task<ClientHistory> GetClientHistory(int id);

        Task<ICollection<Account>> GetAccounts();
    }
}