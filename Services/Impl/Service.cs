using AutoMapper;
using DistripackAPI.Persistence;
using Microsoft.Extensions.Logging;

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
        protected readonly ILogger logger;

        public Service(IMapper mapper, IUnitOfWork unitOfWork, ILogger logger)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

    }
}
