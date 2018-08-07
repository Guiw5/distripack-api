using AutoMapper;
using DistripackAPI.Controllers.Resources;
using DistripackAPI.Models;
using DistripackAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CreateOrderAsync([FromBody] Order order)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pedido = new Pedido
            {
                FechaCreacion = DateTime.Now,
                Estado = EstadoPedido.Creado
            };

            await context.Pedidos.AddAsync(pedido);

            return Ok(order);
        }
    }
}