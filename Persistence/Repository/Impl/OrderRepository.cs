using DistripackAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository.Impl
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<Order> Get(int id)
        {
            return await Context.Orders.Include(o => o.Items).SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<ICollection<Order>> GetAllWithSkus()
        {
            return await Context.Orders.Include(p => p.Items).ThenInclude(i => i.Sku).ToListAsync();
        }

        public async Task<ICollection<Order>> GetAllCreated()
        {
            return await Context.Orders.Where(o => OrderState.Created.Equals(o.State))
                .Include(o => o.Items)
                .ThenInclude(i => i.Sku)
                .OrderBy(o => o.CreatedAt)
                .ToListAsync();
        }

        public async Task<ICollection<Order>> GetAllPendings()
        {
            return await Context.Orders.Where(o => OrderState.Created < o.State)
                .Include(o => o.Items)
                .ThenInclude(i => i.Sku)
                .OrderBy(o => o.DeliveryDate)
                .ToListAsync();
        }


    }
}
