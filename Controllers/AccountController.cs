using DistripackAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace DistripackAPI.Controllers
{
    /// <summary>
    /// Controller for managing client accounts and transactions
    /// </summary>
    [Route("api/accounts")]
    [ApiController]
    [SwaggerTag("Accounts", "Manage client accounts and their balances")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Get all accounts in the system
        /// </summary>
        /// <returns>List of all accounts</returns>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Get all accounts",
            Description = "Retrieves a list of all accounts in the system",
            OperationId = "GetAccounts",
            Tags = new[] { "Accounts" }
        )]
        [SwaggerResponse(200, "The accounts were successfully retrieved")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await accountService.GetAccounts();
            return Ok(accounts);
        }

        /// <summary>
        /// Get checking account for a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <returns>The client's checking account details</returns>
        [HttpGet]
        [Route("{clientId}")]
        [SwaggerOperation(
            Summary = "Get client account",
            Description = "Retrieves the checking account details for a specific client",
            OperationId = "GetCheckingAccount",
            Tags = new[] { "Accounts" }
        )]
        [SwaggerResponse(200, "The account was successfully retrieved")]
        [SwaggerResponse(404, "Client not found or no account associated")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetCheckingAccount(int clientId)
        {
            var account = await accountService.GetCheckingAccount(clientId);
            if (account == null)
                return NotFound($"Client {clientId} does not exist or has no associated account");

            return Ok(account);
        }

        /// <summary>
        /// Set checking account amount for a client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="amount">The amount to set</param>
        /// <returns>The updated account details</returns>
        [HttpPost]
        [Route("{clientId}")]
        [SwaggerOperation(
            Summary = "Set account amount",
            Description = "Sets the checking account amount for a specific client",
            OperationId = "SetCheckingAccount",
            Tags = new[] { "Accounts" }
        )]
        [SwaggerResponse(200, "The account was successfully updated")]
        [SwaggerResponse(404, "Client not found")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> SetCheckingAccount(int clientId, [FromBody] int amount)
        {
            var account = await accountService.SetCheckingAccount(clientId, amount);
            return Ok(account);
        }

        /// <summary>
        /// Set initial amount for a client's account
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <param name="amount">The initial amount to set</param>
        /// <returns>The updated account details</returns>
        [HttpPut]
        [Route("{clientId}")]
        [SwaggerOperation(
            Summary = "Set initial amount",
            Description = "Sets the initial amount for a client's account",
            OperationId = "SetInitialAmount",
            Tags = new[] { "Accounts" }
        )]
        [SwaggerResponse(200, "The initial amount was successfully set")]
        [SwaggerResponse(404, "Client not found")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> SetInitialAmount(int clientId, [FromBody] int amount)
        {
            var account = await accountService.SetInitialAmount(clientId, amount);
            return Ok(account);
        }
    }
}