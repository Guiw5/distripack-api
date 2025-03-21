using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace DistripackAPI.Controllers
{
    /// <summary>
    /// Controller for managing financial transactions in the system
    /// </summary>
    [Route("api/transactions")]
    [ApiController]
    [SwaggerTag("Transactions", "Manage client payments and transaction history")]
    public class TransactionController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IClientService clientService;

        public TransactionController(IAccountService accountService, IClientService clientService)
        {
            this.accountService = accountService;
            this.clientService = clientService;
        }

        /// <summary>
        /// Register a new payment
        /// </summary>
        /// <param name="payment">The payment details to register</param>
        /// <returns>The registered transaction</returns>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Register payment",
            Description = "Registers a new payment transaction for a client",
            OperationId = "RegisterPayment",
            Tags = new[] { "Transactions" }
        )]
        [SwaggerResponse(200, "Payment was successfully registered")]
        [SwaggerResponse(400, "Invalid payment data")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> RegisterPayment(CreatePayment payment)
        {
            var transaction = await accountService.RegisterPayment(payment);
            return Ok(transaction);
        }

        /// <summary>
        /// Get transactions for a specific client
        /// </summary>
        /// <param name="clientId">The ID of the client</param>
        /// <returns>List of client transactions</returns>
        [HttpGet]
        [Route("{clientId}")]
        [SwaggerOperation(
            Summary = "Get client transactions",
            Description = "Retrieves the transaction history for a specific client. Note: This endpoint is pending implementation of custom validations and unit of work pattern for better transaction management.",
            OperationId = "GetClientTransactions",
            Tags = new[] { "Transactions" }
        )]
        [SwaggerResponse(200, "Transactions were successfully retrieved")]
        [SwaggerResponse(404, "Client not found")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetTransactions(int clientId)
        {
            // TODO: Implement custom validations with exceptions for better error handling
            // TODO: Implement unit of work pattern for better transaction management
            var client = await clientService.GetClient(clientId);
            if (client == null)
                return NotFound(clientId);

            var transactions = await accountService.GetTransactions(clientId);
            return Ok(transactions);
        }
    }
}