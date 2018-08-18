using DistripackAPI.Models;

namespace DistripackAPI.Persistence.Repository.Impl
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
