using DistripackAPI.Persistence.Repository;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context, IOrderRepository orders, IClientRepository clients, IProductRepository products,
            IItemRepository items, ICheckingAccountRepository checkingAccounts, ITransactionRepository transactions)
        {
            this.context = context;
            this.Orders = orders;
            this.Clients = clients;
            this.Products = products;
            this.Items = items;
            this.CheckingAccounts = checkingAccounts;
            this.Transactions = transactions;

        }

        public IOrderRepository Orders { get; }

        public IClientRepository Clients { get; }

        public IProductRepository Products { get; }

        public IItemRepository Items { get; }

        public ICheckingAccountRepository CheckingAccounts { get; }

        public ITransactionRepository Transactions { get; }

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
