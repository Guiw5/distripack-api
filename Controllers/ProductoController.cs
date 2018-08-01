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
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductoController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetProductsAsync()
        {
            var products = await context.Productos
                .Include(p => p.ProductoCategorias)
                .ThenInclude(c => c.Categoria)
                .ToListAsync();
            return mapper.Map<List<Producto>, List<ProductResource>>(products);
        }

        [HttpGet("api/categories")]
        public async Task<IEnumerable<CategoryResource>> GetCategoriesAsync()
        {
            var categories = await context.Categorias
                .Include(p => p.ProductoCategorias)
                .ThenInclude(c => c.Producto)
                .ToListAsync();
            return mapper.Map<List<Categoria>, List<CategoryResource>>(categories);
        }
    }
}