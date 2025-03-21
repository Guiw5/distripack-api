using DistripackAPI.Controllers.ApiModels;
using DistripackAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace DistripackAPI.Controllers
{
    /// <summary>
    /// Controller for managing orders in the system
    /// </summary>
    [Route("api/orders")]
    [ApiController]
    [SwaggerTag("Orders", "Manage orders and their lifecycle")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        /// <summary>
        /// Get a specific order by ID
        /// </summary>
        /// <param name="id">The ID of the order</param>
        /// <returns>The order details</returns>
        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(
            Summary = "Get order by ID",
            Description = "Retrieves the details of a specific order",
            OperationId = "GetOrder",
            Tags = new[] { "Orders" }
        )]
        [SwaggerResponse(200, "The order was successfully retrieved")]
        [SwaggerResponse(404, "Order not found")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await orderService.Get(id);

            if (order == null)
                return NotFound(id);

            return Ok(order);
        }

        /// <summary>
        /// Create a new order
        /// </summary>
        /// <param name="apiOrder">The order details to create</param>
        /// <returns>The created order</returns>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create order",
            Description = "Creates a new order in the system",
            OperationId = "CreateOrder",
            Tags = new[] { "Orders" }
        )]
        [SwaggerResponse(200, "The order was successfully created")]
        [SwaggerResponse(400, "Invalid order data")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrder apiOrder)
        {
            var order = await orderService.Create(apiOrder);
            return Ok(order);
        }

        /// <summary>
        /// Modify an existing order
        /// </summary>
        /// <param name="apiOrder">The updated order details</param>
        /// <returns>The modified order</returns>
        [HttpPut]
        [SwaggerOperation(
            Summary = "Modify order",
            Description = "Updates an existing order in the system",
            OperationId = "ModifyOrder",
            Tags = new[] { "Orders" }
        )]
        [SwaggerResponse(200, "The order was successfully updated")]
        [SwaggerResponse(404, "Order not found")]
        [SwaggerResponse(400, "Invalid order data")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> ModifyOrder([FromBody] UpdateOrder apiOrder)
        {
            var order = await orderService.Modify(apiOrder);

            if (order == null)
                return NotFound(apiOrder);

            return Ok(order);
        }

        /// <summary>
        /// Print multiple orders
        /// </summary>
        /// <param name="orderIds">Array of order IDs to print</param>
        /// <returns>Print response</returns>
        [HttpPut]
        [Route("print")]
        [SwaggerOperation(
            Summary = "Print orders",
            Description = "Prints multiple orders in the system",
            OperationId = "PrintOrders",
            Tags = new[] { "Orders" }
        )]
        [SwaggerResponse(200, "Orders were successfully printed")]
        [SwaggerResponse(400, "Invalid order IDs")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> Print([FromBody] int[] orderIds)
        {
            var orders = new List<int>(orderIds);
            var response = await orderService.Print(orders);
            return Ok(response);
        }

        /// <summary>
        /// Mark multiple orders as delivered
        /// </summary>
        /// <param name="orderIds">Array of order IDs to mark as delivered</param>
        /// <returns>Delivery response</returns>
        [HttpPut]
        [Route("deliver")]
        [SwaggerOperation(
            Summary = "Deliver orders",
            Description = "Marks multiple orders as delivered",
            OperationId = "DeliverOrders",
            Tags = new[] { "Orders" }
        )]
        [SwaggerResponse(200, "Orders were successfully marked as delivered")]
        [SwaggerResponse(400, "Invalid order IDs")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> Deliver([FromBody] int[] orderIds)
        {
            var orders = new List<int>(orderIds);
            var response = await orderService.Deliver(orders);
            return Ok(response);
        }

        /// <summary>
        /// Delete multiple orders
        /// </summary>
        /// <param name="orderIds">Array of order IDs to delete</param>
        /// <returns>Delete response</returns>
        [HttpDelete]
        [SwaggerOperation(
            Summary = "Delete orders",
            Description = "Deletes multiple orders from the system",
            OperationId = "DeleteOrders",
            Tags = new[] { "Orders" }
        )]
        [SwaggerResponse(200, "Orders were successfully deleted")]
        [SwaggerResponse(400, "Invalid order IDs")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> Delete([FromBody] int[] orderIds)
        {
            var orders = new List<int>(orderIds);
            var response = await orderService.Delete(orders);
            return Ok(response);
        }

        /// <summary>
        /// Get all created orders
        /// </summary>
        /// <returns>List of created orders</returns>
        [HttpGet]
        [Route("created")]
        [SwaggerOperation(
            Summary = "Get created orders",
            Description = "Retrieves all orders in created status",
            OperationId = "GetCreatedOrders",
            Tags = new[] { "Orders" }
        )]
        [SwaggerResponse(200, "Orders were successfully retrieved")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetOrders()
        {
            var apiOrders = await orderService.GetAllCreated();
            return Ok(apiOrders);
        }

        /// <summary>
        /// Get all pending orders
        /// </summary>
        /// <returns>List of pending orders</returns>
        [HttpGet]
        [Route("pendings")]
        [SwaggerOperation(
            Summary = "Get pending orders",
            Description = "Retrieves all orders in pending status",
            OperationId = "GetPendingOrders",
            Tags = new[] { "Orders" }
        )]
        [SwaggerResponse(200, "Orders were successfully retrieved")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetPendings()
        {
            var apiOrders = await orderService.GetAllPendings();
            return Ok(apiOrders);
        }

        /// <summary>
        /// Get latest delivered orders
        /// </summary>
        /// <returns>List of recently delivered orders</returns>
        [HttpGet]
        [Route("delivered")]
        [SwaggerOperation(
            Summary = "Get delivered orders",
            Description = "Retrieves the most recently delivered orders",
            OperationId = "GetDeliveredOrders",
            Tags = new[] { "Orders" }
        )]
        [SwaggerResponse(200, "Orders were successfully retrieved")]
        [SwaggerResponse(401, "Unauthorized")]
        public async Task<IActionResult> GetDelivered()
        {
            var apiOrders = await orderService.GetLatestDelivered();
            return Ok(apiOrders);
        }
    }
}