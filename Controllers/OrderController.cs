using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var order = await orderService.Create(apiOrder);

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }


        [HttpPut]
        public async Task<IActionResult> ModifyOrder([FromBody] UpdateOrder apiOrder)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var order = await orderService.Modify(apiOrder);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        [HttpPut]
        [Route("print")]
        public async Task<IActionResult> Print([FromBody] int[] orderIds)
        {
            try
            {
                var orders = new List<int>(orderIds);
                await orderService.Print(orders);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        [HttpPut]
        [Route("deliver")]
        public async Task<IActionResult> Deliver([FromBody] int[] orderIds)
        {
            try
            {
                var orders = new List<int>(orderIds);
                await orderService.Deliver(orders);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int[] orderIds)
        {
            try
            {
                var orders = new List<int>(orderIds);
                await orderService.Delete(orders);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var apiOrders = await orderService.GetAllCreated();
                return Ok(apiOrders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("pendings")]
        [HttpGet]
        public async Task<IActionResult> GetPendings()
        {
            try
            {
                var apiOrders = await orderService.GetAllPendings();
                return Ok(apiOrders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("delivered")]
        [HttpGet]
        public async Task<IActionResult> GetDelivered()
        {
            try
            {
                var apiOrders = await orderService.GetAllDelivered();
                return Ok(apiOrders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}