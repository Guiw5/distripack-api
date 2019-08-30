using DistripackAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository
{
    public interface ICheckingAccountRepository : IRepository<CheckingAccount>
    {
        Task<ICollection<CheckingAccount>> GetAll();
    }
}