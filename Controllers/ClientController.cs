using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace DistripackAPI.Controllers
{
    /// <summary>
    /// Controller for managing clients in the system
    /// </summary>
    [Route("api/clients")]
    [ApiController]
    [SwaggerTag("Clients", "Manage client information and operations")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns>List of all clients</returns>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all clients",
            Description = "Retrieves a list of all clients in the system",
            OperationId = "GetClients",
            Tags = new[] { "Clients" }
        )]
        [SwaggerResponse(200, "Clients were successfully retrieved")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetClients()
        {
            var clients = await clientService.GetAll();
            return Ok(clients);
        }

        /// <summary>
        /// Get all clients with full details
        /// </summary>
        /// <returns>List of all clients with complete information</returns>
        [HttpGet]
        [Route("full")]
        [SwaggerOperation(
            Summary = "Get full client details",
            Description = "Retrieves a list of all clients with their complete information",
            OperationId = "GetFullClients",
            Tags = new[] { "Clients" }
        )]
        [SwaggerResponse(200, "Clients were successfully retrieved")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetFullClients()
        {
            var clients = await clientService.GetAllFull();
            return Ok(clients);
        }

        /// <summary>
        /// Get a specific client by ID
        /// </summary>
        /// <param name="id">The ID of the client</param>
        /// <returns>The client details</returns>
        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(
            Summary = "Get client by ID",
            Description = "Retrieves the details of a specific client",
            OperationId = "GetClient",
            Tags = new[] { "Clients" }
        )]
        [SwaggerResponse(200, "Client was successfully retrieved")]
        [SwaggerResponse(404, "Client not found")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetClient(int id)
        {
            var client = await clientService.GetClient(id);

            if (client == null)
                return NotFound(id);

            return Ok(client);
        }

        /// <summary>
        /// Get client history
        /// </summary>
        /// <param name="id">The ID of the client</param>
        /// <returns>The client's history</returns>
        [HttpGet]
        [Route("{id}/history")]
        [SwaggerOperation(
            Summary = "Get client history",
            Description = "Retrieves the history of activities for a specific client",
            OperationId = "GetClientHistory",
            Tags = new[] { "Clients" }
        )]
        [SwaggerResponse(200, "Client history was successfully retrieved")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetHistory(int id)
        {
            var clientHistory = await clientService.GetClientHistory(id);
            return Ok(clientHistory);
        }

        /// <summary>
        /// Create a new client
        /// </summary>
        /// <param name="apiClient">The client details to create</param>
        /// <returns>The created client</returns>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create client",
            Description = "Creates a new client in the system",
            OperationId = "CreateClient",
            Tags = new[] { "Clients" }
        )]
        [SwaggerResponse(200, "Client was successfully created")]
        [SwaggerResponse(400, "Invalid client data")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> CreateClient([FromBody] CreateThinClient apiClient)
        {
            var client = await clientService.Create(apiClient);
            return Ok(client);
        }

        /// <summary>
        /// Create a new web client
        /// </summary>
        /// <param name="apiClient">The web client details to create</param>
        /// <returns>The created web client</returns>
        [HttpPost]
        [Route("web")]
        [SwaggerOperation(
            Summary = "Create web client",
            Description = "Creates a new web client in the system",
            OperationId = "CreateWebClient",
            Tags = new[] { "Clients" }
        )]
        [SwaggerResponse(200, "Web client was successfully created")]
        [SwaggerResponse(400, "Invalid client data")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> CreateWebClient([FromBody] CreateWebClient apiClient)
        {
            var client = await clientService.Create(apiClient);
            return Ok(client);
        }

        /// <summary>
        /// Modify an existing client
        /// </summary>
        /// <param name="apiClient">The updated client details</param>
        /// <returns>Success status</returns>
        [HttpPut]
        [SwaggerOperation(
            Summary = "Modify client",
            Description = "Updates an existing client in the system",
            OperationId = "ModifyClient",
            Tags = new[] { "Clients" }
        )]
        [SwaggerResponse(200, "Client was successfully updated")]
        [SwaggerResponse(404, "Client not found")]
        [SwaggerResponse(400, "Invalid client data")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> ModifyClient([FromBody] UpdateClient apiClient)
        {
            var client = await clientService.Modify(apiClient);

            if (client == null)
                return NotFound(apiClient);

            return Ok();
        }
    }
}
