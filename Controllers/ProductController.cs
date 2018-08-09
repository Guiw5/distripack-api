using AutoMapper;
using DistripackAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistripackAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var productos = await context.Products
                .GroupBy(x => x.Id)
                .ToListAsync();

            return Ok(productos);
        }

        [HttpGet]
        [Route("api/categories")]
        public async Task<IEnumerable<ApiModels.Category>> GetCategoriesAsync()
        {
            var categories = await context.Categories
                .Include(p => p.ProductCategories)
                .ThenInclude(c => c.Product)
                .ToListAsync();
            return mapper.Map<List<Models.Category>, List<ApiModels.Category>>(categories);
        }
    }
}