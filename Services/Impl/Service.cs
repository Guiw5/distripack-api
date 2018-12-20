using AutoMapper;
using DistripackAPI.Persistence;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace DistripackAPI.Services.Impl
{
    public abstract class Service : IService
    {
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork unitOfWork;

        public Service(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

    }
}
