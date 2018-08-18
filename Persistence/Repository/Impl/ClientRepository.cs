using DistripackAPI.Models;

namespace DistripackAPI.Persistence.Repository.Impl
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
