using System.Threading.Tasks;

namespace DistripackAPI.Persistence
{
    public interface IUnitOfWork
    {
        Task Complete();
    }
}
