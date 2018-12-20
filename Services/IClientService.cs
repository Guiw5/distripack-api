using DistripackAPI.Controllers.ApiModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Services
{
    public interface IClientService
    {
        Task<Client> Create(CreateClient apiClient);

        Task<ICollection<Client>> GetAll();
    }
}
