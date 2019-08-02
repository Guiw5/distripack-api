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
                var order = await orderService.Modify(apiOrder);

                if (order == null)
                    return NotFound(order);

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
                var response = await orderService.Print(orders);
                return Ok(response);
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
                var response = await orderService.Deliver(orders);
                return Ok(response);
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
                var response = await orderService.Delete(orders);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpGet]
        [Route("created")]
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


        [HttpGet]
        [Route("pendings")]
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

        [HttpGet]
        [Route("delivered")]
        public async Task<IActionResult> GetDelivered()
        {
            try
            {
                var apiOrders = await orderService.GetLatestDelivered();
                return Ok(apiOrders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}