using DistripackAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace DistripackAPI.Controllers
{
    /// <summary>
    /// Controller for managing products in the system
    /// </summary>
    [Route("api/products")]
    [ApiController]
    [SwaggerTag("Products", "Manage products and SKUs")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of all products</returns>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all products",
            Description = "Retrieves a list of all products in the system",
            OperationId = "GetProducts",
            Tags = new[] { "Products" }
        )]
        [SwaggerResponse(200, "Products were successfully retrieved")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetAll();
            return Ok(products);
        }

        /// <summary>
        /// Get all SKUs
        /// </summary>
        /// <returns>List of all SKUs</returns>
        [HttpGet]
        [Route("~/api/skus")]
        [SwaggerOperation(
            Summary = "Get all SKUs",
            Description = "Retrieves a list of all SKUs in the system",
            OperationId = "GetSkus",
            Tags = new[] { "Products" }
        )]
        [SwaggerResponse(200, "SKUs were successfully retrieved")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetSkus()
        {
            var products = await productService.GetSkus();
            return Ok(products);
        }
    }
}