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

        [HttpGet]
        [Route("full")]
        public async Task<IActionResult> GetFullClients()
        {
            try
            {
                var clients = await clientService.GetAllFull();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetClient(int id)
        {
            try
            {
                var client = await clientService.GetClient(id);
                if (client == null)
                    return NotFound(id);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("{id}/history")]
        public async Task<IActionResult> GetHistory(int id)
        {
            try
            {
                var clientHistory = await clientService.GetClientHistory(id);
                return Ok(clientHistory);
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
                var client = await clientService.Create(apiClient);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        [Route("web")]
        public async Task<IActionResult> CreateWebClient([FromBody] CreateWebClient apiClient)
        {
            try
            {
                var client = await clientService.Create(apiClient);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPut]
        public async Task<IActionResult> ModifyClient([FromBody] UpdateClient apiClient)
        {
            try
            {
                var client = await clientService.Modify(apiClient);
                if (client == null)
                    return NotFound(apiClient);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
