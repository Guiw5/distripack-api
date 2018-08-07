using AutoMapper;
using DistripackAPI.Controllers.Resources;
using DistripackAPI.Models;
using DistripackAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DistripackAPI.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ClientController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientsAsync()
        {
            var clientes = await context.Clientes.ToListAsync();
            var clients = mapper.Map<Cliente, Client>(null);
            return Ok(clients);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] string value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var cliente = await context.Clientes.AddAsync(new Cliente());

            var rta = await context.SaveChangesAsync();
            return Ok(cliente);

        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
