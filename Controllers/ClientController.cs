using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DistripackAPI.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            try
            {
                var clients = await clientService.GetAll();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClient apiClient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var client = await clientService.Create(apiClient);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
