using DistripackAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

            //retrieving last year transactions
            var lastYear = DateTime.Today.AddDays(-365);

            return await Context.Transactions
                .Include(x => x.CheckingAccount)
                .Where(x => x.CheckingAccount.ClientId == clientId && x.CreatedAt > lastYear)
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();

            //todo compare performance query with this other way
            //var client = await Context.Clients
            //    .Where(c => c.Id == clientId)
            //    .Include(c => c.CheckingAccount)
            //    .ThenInclude(c => c.Transactions
            //        .Where(t => t.CreatedAt.CompareTo(lastYear) > 0)
            //        .OrderBy(t => t.CreatedAt))
            //    .SingleOrDefaultAsync();


            //return client.CheckingAccount.Transactions;
        }
    }
}