using DistripackAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public async override Task<Client> Get(int id)
        {
            return await Context.Clients
                .Include(c => c.CheckingAccount)
                .SingleOrDefaultAsync(c => c.Id == id);
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
                .SingleOrDefaultAsync();
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

        public async Task<ICollection<Client>> GetAll()
        {
            return await Context.Clients
                .Include(c => c.CheckingAccount)
                .ToListAsync();
        }
    }
}
