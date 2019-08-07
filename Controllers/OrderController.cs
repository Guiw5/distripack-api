using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DistripackAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrder apiOrder)
        {
            var order = await orderService.Create(apiOrder);
            return Ok(order);
        }


        [HttpPut]
        public async Task<IActionResult> ModifyOrder([FromBody] UpdateOrder apiOrder)
        {
            var order = await orderService.Modify(apiOrder);

            if (order == null)
                return NotFound(apiOrder);

            return Ok(order);
        }

        [HttpPut]
        [Route("print")]
        public async Task<IActionResult> Print([FromBody] int[] orderIds)
        {
            var orders = new List<int>(orderIds);
            var response = await orderService.Print(orders);
            return Ok(response);

        }

        [HttpPut]
        [Route("deliver")]
        public async Task<IActionResult> Deliver([FromBody] int[] orderIds)
        {
            var orders = new List<int>(orderIds);
            var response = await orderService.Deliver(orders);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int[] orderIds)
        {
            var orders = new List<int>(orderIds);
            var response = await orderService.Delete(orders);
            return Ok(response);
        }


        [HttpGet]
        [Route("created")]
        public async Task<IActionResult> GetOrders()
        {
            var apiOrders = await orderService.GetAllCreated();
            return Ok(apiOrders);
        }


        [HttpGet]
        [Route("pendings")]
        public async Task<IActionResult> GetPendings()
        {
            var apiOrders = await orderService.GetAllPendings();
            return Ok(apiOrders);

        }

        [HttpGet]
        [Route("delivered")]
        public async Task<IActionResult> GetDelivered()
        {
            var apiOrders = await orderService.GetLatestDelivered();
            return Ok(apiOrders);
        }
    }
}