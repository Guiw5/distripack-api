using DistripackAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DistripackAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetAll();
            return Ok(products);
        }


        [HttpGet]
        [Route("~/api/skus")]
        public async Task<IActionResult> GetSkus()
        {
            var products = await productService.GetSkus();
            return Ok(products);
        }
    }
}