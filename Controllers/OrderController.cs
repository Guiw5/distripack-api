using AutoMapper;
using DistripackAPI.Models;
using DistripackAPI.Persistence;
using DistripackAPI.Persistence.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DistripackAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository repository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IOrderRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] ApiModels.Post.Order apiOrder)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);


                var order = mapper.Map<Order>(apiOrder);

                order.State = OrderState.Created;
                var orderEntry = await repository.Add(order);
                await unitOfWork.Complete();
                apiOrder = mapper.Map<ApiModels.Post.Order>(orderEntry.Entity);
                return Ok(apiOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}