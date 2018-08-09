using AutoMapper;
using DistripackAPI.Models;
using DistripackAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Order = DistripackAPI.Models.Order;

namespace DistripackAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public OrderController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] ApiModels.Order order)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pedido = new Order
            {
                CreatedAt = DateTime.Now,
                State = OrderState.Created
            };

            await context.Orders.AddAsync(pedido);

            return Ok(order);
        }
    }
}