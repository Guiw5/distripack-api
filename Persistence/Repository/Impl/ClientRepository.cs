using DistripackAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository.Impl
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ICollection<Order>> FindHistory(int clientId)
        {
            return await Context.Orders
                .Where(o => o.ClientId == clientId && OrderState.Delivered.Equals(o.State))
                .OrderBy(o => o.DeliveredAt)
                .Include(o => o.Items)
                .ThenInclude(i => i.Sku)
                .ToListAsync();
        }

        public async Task<Client> GetWithAccount(int clientId)
        {
            return await Context.Clients
                .Where(c => c.Id == clientId)
                .Include(c => c.CheckingAccount)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }


        public async Task<ICollection<Transaction>> GetTransactions(int clientId)
        {
            //retrieving last two months of transactions
            var twoMonthsAgo = DateTime.Today.AddDays(-60);
            return await Context.Transactions
                .Include(t => t.CheckingAccount)
                .Where(t => t.CheckingAccount.ClientId == clientId && t.CreatedAt.CompareTo(twoMonthsAgo) > 0)
                .OrderBy(t => t.CreatedAt)
                .ToListAsync();

            //var client = await Context.Clients
            //.Where(c => c.Id == clientId)
            //.Include(c => c.CheckingAccount)
            //.ThenInclude(c => c.Transactions)
            //.SingleOrDefaultAsync();


            //return client.CheckingAccount.Transactions;
        }



        /// <summary>
        ///    This method should be linked to a checking account
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<double> GetBalance(int clientId)
        {

            var account = await Context.CheckingAccounts
                .Where(c => c.ClientId == clientId)
                .SingleOrDefaultAsync();

            return account.CurrentBalance;

        }
    }
}
