using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DistripackAPI.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;
        private readonly IClientService clientService;

        public TransactionController(ITransactionService transactionService, IClientService clientService)
        {
            this.transactionService = transactionService;
            this.clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPayment(CreatePayment payment)
        {
            var transaction = await transactionService.RegisterPayment(payment);
            return Ok(transaction);
        }

        [HttpGet]
        [Route("{clientId}")]
        public async Task<IActionResult> GetTransactions(int clientId)
        {
            //todo add custom validations with exceptions
            //todo check unitOfWork pattern implementation in link
            var client = await clientService.GetClient(clientId);
            if (client == null)
                return NotFound(clientId);

            var transactions = await transactionService.GetTransactions(clientId);
            return Ok(transactions);
        }

        [HttpGet]
        [Route("{clientId}/account")]
        public async Task<IActionResult> GetCheckingAccount(int clientId)
        {
            var account = await transactionService.GetCheckingAccount(clientId);
            return Ok(account);
        }

        [HttpPost]
        [Route("{clientId}/account")]
        public async Task<IActionResult> SetCheckingAccount(int clientId, [FromBody] int amount)
        {
            var account = await transactionService.SetCheckingAccount(clientId, amount);
            return Ok(account);
        }
    }
}