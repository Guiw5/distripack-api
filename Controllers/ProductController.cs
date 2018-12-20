using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var productos = await unitOfWork.Products.GetAll();
                var products = mapper.Map<IList<Product>>(productos);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}