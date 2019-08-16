using DistripackAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository.Impl
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<ICollection<Transaction>> GetByClient(int clientId)
        {
            ////todo getting full list of transactions, add filter by 2 months ago?
            return await Context.Transactions
                .Include(x => x.CheckingAccount)
                .Where(x => x.CheckingAccount.ClientId == clientId)
                .ToListAsync();
        }
    }
}