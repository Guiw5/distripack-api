using AutoMapper;
using DistripackAPI.Controllers.Resources;
using DistripackAPI.Models;
using DistripackAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await context.Productos
                .Include(p => p.ProductoCategorias)
                .ThenInclude(c => c.Categoria)
                .ToListAsync();
            return mapper.Map<List<Producto>, List<Product>>(products);
        }

        [HttpGet("api/categories")]
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = await context.Categorias
                .Include(p => p.ProductoCategorias)
                .ThenInclude(c => c.Producto)
                .ToListAsync();
            return mapper.Map<List<Categoria>, List<Category>>(categories);
        }
    }
}