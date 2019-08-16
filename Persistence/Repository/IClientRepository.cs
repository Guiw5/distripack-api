using DistripackAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<ICollection<Order>> FindHistory(int clientId);

        Task<double> GetBalance(int id);

        Task<Client> GetWithAccount(int id);
    }
}
