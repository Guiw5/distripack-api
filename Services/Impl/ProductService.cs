using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Persistence;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace DistripackAPI.Services.Impl
{
    public class ProductService : Service, IProductService
    {
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, ILogger<ProductService> logger)
            : base(mapper, unitOfWork, logger) { }

        public async Task<ICollection<Product>> GetAll()
        {
            var products = await unitOfWork.Products.GetAll();
            return mapper.Map<IList<Product>>(products);
        }


    }
}
