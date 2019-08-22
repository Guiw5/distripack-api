using DistripackAPI.Models;
//using System.Collections.Generic;
namespace DistripackAPI.Persistence.Repository.Impl
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
