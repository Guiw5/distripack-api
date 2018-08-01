using AutoMapper;
using DistripackAPI.Controllers.Resources;
using DistripackAPI.Models;
using DistripackAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DistripackAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PedidoController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        public async Task<OrderResource> CrearPedidoAsync([FromBody] OrderResource order)
        {
            var pedido = mapper.Map<OrderResource, Pedido>(order);
            //var products = await context.
            //    .Include(p => p.ProductoCategorias)
            //    .ThenInclude(c => c.Categoria)
            //    .ToListAsync();
            return order;
        }
    }
}