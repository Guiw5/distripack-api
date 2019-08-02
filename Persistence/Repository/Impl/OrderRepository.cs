using DistripackAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
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

        public async Task<ICollection<Order>> FindAllWithSkus(IList<int> orderIds)
        {
            return await Context.Orders.Where(o => orderIds.Contains(o.Id))
                .Include(o => o.Items)
                .ThenInclude(i => i.Sku)
                .OrderBy(o => o.CreatedAt)
                .ToListAsync();
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
            return await Context.Orders.Where(o => OrderState.Created < o.State && OrderState.Delivered > o.State)
                .Include(o => o.Items)
                .ThenInclude(i => i.Sku)
                .OrderBy(o => o.DeliveryDate)
                .ToListAsync();
        }

        public async Task<ICollection<Order>> GetAllDelivered()
        {
            return await Context.Orders.Where(o => OrderState.Delivered.Equals(o.State))
                .Include(o => o.Items)
                .ThenInclude(i => i.Sku)
                .OrderByDescending(o => o.DeliveryDate)
                .ToListAsync();
        }


        public async Task<ICollection<Order>> GetLatestDelivered()
        {
            var aMonthAgo = DateTime.Today.AddDays(-30);
            return await Context.Orders.Where(o => OrderState.Delivered.Equals(o.State) && o.DeliveredAt.Value.CompareTo(aMonthAgo) > 0)
                .Include(o => o.Items)
                .ThenInclude(i => i.Sku)
                .OrderByDescending(o => o.DeliveryDate)
                .ToListAsync();
        }

        public override EntityEntry<Order> Add(Order order)
        {
            var orderEntry = base.Add(order);
            //explicit eager load (before db.SaveChanges())
            //orderDb.Collection(o => o.Items).Query().Include(i => i.Sku).Load();
            return orderEntry;


        }

        public async Task<Order> GetWithSku(int id)
        {
            return await Context.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Sku)
                .SingleOrDefaultAsync(o => o.Id == id);
        }


    }
}
