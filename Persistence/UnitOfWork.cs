using DistripackAPI.Persistence.Repository;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context, IOrderRepository orders, IClientRepository clients, IProductRepository products, IItemRepository items)
        {
            this.context = context;
            this.Orders = orders;
            this.Clients = clients;
            this.Products = products;
            this.Items = items;
        }

        public IOrderRepository Orders { get; }

        public IClientRepository Clients { get; }

        public IProductRepository Products { get; }

        public IItemRepository Items { get; }

        public async Task Complete()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
