using AutoMapper;
using DistripackAPI.Controllers.ApiModels.Get;
using DistripackAPI.Persistence.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var productos = await repository.GetAll();
            var products = mapper.Map<List<Product>>(productos);
            return Ok(products);
        }
    }
}