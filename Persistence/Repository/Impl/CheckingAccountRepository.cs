using DistripackAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository.Impl
{
    public class CheckingAccountRepository : Repository<CheckingAccount>, ICheckingAccountRepository
    {
        public CheckingAccountRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<ICollection<CheckingAccount>> GetAll()
        {
            return await Context.CheckingAccounts
                .Include(c => c.Client)
                .ToListAsync();
        }

        public override async Task<CheckingAccount> Get(int id)
        {
            return await Context.CheckingAccounts
                .Where(c => c.ClientId == id)
                .Include(c => c.Client)
                .SingleOrDefaultAsync();
        }
    }
}