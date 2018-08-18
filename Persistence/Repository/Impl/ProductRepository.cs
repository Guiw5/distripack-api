using DistripackAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository.Impl
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<Product> GetWithSkus(int id)
        {
            return await DbContext.Products
                .Include(p => p.Skus)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<ICollection<Product>> GetAll()
        {
            return await DbContext.Products
                .Include(p => p.Skus)
                .ToListAsync();
        }

        public ApplicationDbContext DbContext => Context as ApplicationDbContext;
    }
}
