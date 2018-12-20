using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoryController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCategoriessAsync()
        {
            var categories = await context.Categories
                //.Include(c => c.ProductCategories)
                //.ThenInclude(pc => pc.Product)
                //.ThenInclude(p => p.Skus)
                .ToListAsync();
            var cats = mapper.Map<List<Category>>(categories);
            return Ok(cats);
        }

        [HttpGet]
        [Route("/v2")]
        public async Task<IEnumerable<Category>> GetCategories2Async()
        {
            var categories = await context.Categories
                .Include(p => p.ProductCategories)
                .ThenInclude(c => c.Product)
                .ToListAsync();
            return mapper.Map<List<Category>>(categories);
        }
    }
}