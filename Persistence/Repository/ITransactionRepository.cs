using DistripackAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<ICollection<Transaction>> GetByClient(int clientId);
    }
}