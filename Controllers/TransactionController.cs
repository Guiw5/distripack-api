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
        private readonly IAccountService accountService;
        private readonly IClientService clientService;

        public TransactionController(IAccountService accountService, IClientService clientService)
        {
            this.accountService = accountService;
            this.clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPayment(CreatePayment payment)
        {
            var transaction = await accountService.RegisterPayment(payment);
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

            var transactions = await accountService.GetTransactions(clientId);
            return Ok(transactions);
        }
    }
}