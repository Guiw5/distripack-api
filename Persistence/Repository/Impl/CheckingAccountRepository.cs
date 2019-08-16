using DistripackAPI.Models;

namespace DistripackAPI.Persistence.Repository.Impl
{
    public class CheckingAccountRepository : Repository<CheckingAccount>, ICheckingAccountRepository
    {
        public CheckingAccountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}