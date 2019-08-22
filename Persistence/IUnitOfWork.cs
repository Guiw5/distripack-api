using DistripackAPI.Persistence.Repository;
using System;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }

        IOrderRepository Orders { get; }

        IProductRepository Products { get; }

        IItemRepository Items { get; }

        Task Complete();
    }
}
