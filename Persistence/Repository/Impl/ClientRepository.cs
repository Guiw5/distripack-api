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

        public async Task<ICollection<Order>> FindHistory(int clientId)
        {
            return await Context.Orders
                .Where(o => o.ClientId == clientId && OrderState.Delivered.Equals(o.State))
                .OrderBy(o => o.DeliveredAt)
                .Include(o => o.Items)
                .ThenInclude(i => i.Sku)
                .ToListAsync();
        }

        /// <summary>
        ///    This method should be linked to a checking account
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<double> GetBalance(int clientId)
        {
            return await Context.Orders
                .Where(o => o.ClientId == clientId && OrderState.Delivered.Equals(o.State))
                .SumAsync(o => o.Subtotal);
        }
    }
}
