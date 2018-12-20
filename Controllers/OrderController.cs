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
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrder apiOrder)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var order = await orderService.Update(apiOrder);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        [HttpPut]
        [Route("print")]
        public async Task<IActionResult> Print([FromQuery] int[] orderIds)
        {
            try
            {
                var orders = new List<int>(orderIds);
                await orderService.PrintAsync(orders);
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

        [Route("history")]
        [HttpGet]
        public async Task<IActionResult> GetHistory()
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
    }
}