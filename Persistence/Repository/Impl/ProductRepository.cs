using DistripackAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistripackAPI.Persistence.Repository.Impl
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<Product> GetWithSkus(int id)
        {
            return await Context.Products
                .Include(p => p.Skus)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await Context.Products
                .Include(p => p.Skus.OrderByDescending(s => s.Quantity))
                .ToListAsync();
        }
    }
}
