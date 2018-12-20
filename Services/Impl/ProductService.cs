using AutoMapper;
using DistripackAPI.Persistence;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace DistripackAPI.Services.Impl
{
    public class ProductService : Service, IProductService
    {
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
            : base(mapper, unitOfWork) { }
    }
}
