using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Services;
using Microsoft.AspNetCore.Mvc;
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
            var clients = await clientService.GetAll();
            return Ok(clients);
        }

        [HttpGet]
        [Route("full")]
        public async Task<IActionResult> GetFullClients()
        {
            var clients = await clientService.GetAllFull();
            return Ok(clients);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await clientService.GetClient(id);

            if (client == null)
                return NotFound(id);

            return Ok(client);
        }

        [HttpGet]
        [Route("{id}/history")]
        public async Task<IActionResult> GetHistory(int id)
        {
            var clientHistory = await clientService.GetClientHistory(id);
            return Ok(clientHistory);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] CreateClient apiClient)
        {
            var client = await clientService.Create(apiClient);
            return Ok(client);
        }

        [HttpPost]
        [Route("web")]
        public async Task<IActionResult> CreateWebClient([FromBody] CreateWebClient apiClient)
        {
            var client = await clientService.Create(apiClient);
            return Ok(client);
        }

        [HttpPut]
        public async Task<IActionResult> ModifyClient([FromBody] UpdateClient apiClient)
        {
            var client = await clientService.Modify(apiClient);

            if (client == null)
                return NotFound(apiClient);

            return Ok();
        }
    }
}
