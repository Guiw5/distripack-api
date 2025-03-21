using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace DistripackAPI.Controllers
{
    /// <summary>
    /// Controller for managing product categories in the system
    /// </summary>
    [Route("api/categories")]
    [ApiController]
    [SwaggerTag("Categories", "Manage product categories and their relationships")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoryController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        /// <summary>
        /// Get all categories with their products and SKUs
        /// </summary>
        /// <returns>List of categories with full product details</returns>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all categories",
            Description = "Retrieves all categories including their associated products and SKUs",
            OperationId = "GetCategories",
            Tags = new[] { "Categories" }
        )]
        [SwaggerResponse(200, "Categories were successfully retrieved")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await context.Categories
                .Include(c => c.ProductCategories)
                .ThenInclude(pc => pc.Product)
                .ThenInclude(p => p.Skus)
                .ToListAsync();
            var cats = mapper.Map<List<Category>>(categories);
            return Ok(cats);
        }

        /// <summary>
        /// Get all categories with their products (v2)
        /// </summary>
        /// <returns>List of categories with product details</returns>
        [HttpGet]
        [Route("/v2")]
        [SwaggerOperation(
            Summary = "Get all categories v2",
            Description = "Retrieves all categories including their associated products (version 2). This version provides a more optimized response by excluding SKU information, which is useful when only product-level details are needed.",
            OperationId = "GetCategoriesV2",
            Tags = new[] { "Categories" }
        )]
        [SwaggerResponse(200, "Categories were successfully retrieved")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IEnumerable<Category>> GetCategoriesV2()
        {
            var categories = await context.Categories
                .Include(p => p.ProductCategories)
                .ThenInclude(c => c.Product)
                .ToListAsync();
            return mapper.Map<List<Category>>(categories);
        }
    }
}