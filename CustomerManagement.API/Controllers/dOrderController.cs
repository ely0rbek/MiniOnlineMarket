using CustomerManagement.API.Attributes;
using CustomerManagement.API.ExternalServices;
using CustomerManagement.Application.Services.OrderServices;
using CustomerManagement.Application.Services.ProductServices;
using CustomerManagement.Domain.Entities.DTOs;
using CustomerManagement.Domain.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class dOrderController : Controller
    {
        private readonly IOrderService _orderService;

        public dOrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [IdentityFilter(Permissions.CreateOrder)]
        public async Task<IActionResult> CreateOrder(OrderDTO orderDTO)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userId = SolveToken.DecodeJwtToken(token, "assalomejesbsjjsbdewbiebelykubvulgborbek");
            return Ok(await _orderService.CreateOrder(Convert.ToInt32(userId),orderDTO));
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetAllOrders)]
        public async Task<IActionResult> GetAllOrders()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userId = SolveToken.DecodeJwtToken(token, "assalomejesbsjjsbdewbiebelykubvulgborbek");

            return Ok(await _orderService.GetAllOrders(Convert.ToInt32(userId)));
        }

        [HttpGet]
        [IdentityFilter(Permissions.GetOrderByName)]
        public async Task<IActionResult> GetOrderByName(string productName)
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userId = SolveToken.DecodeJwtToken(token, "assalomejesbsjjsbdewbiebelykubvulgborbek");

            return Ok(await _orderService.GetOrderByName(Convert.ToInt32(userId),productName));
        }

        [HttpPut]
        [IdentityFilter(Permissions.UpdateOrderById)]
        public async Task<IActionResult> UpdateOrderById( int orderId, OrderDTO orderDTO)
        {
            return Ok(await _orderService.UpdateOrderById(orderId, orderDTO));
        }
        [HttpDelete]
        [IdentityFilter(Permissions.DeleteOrderById)]
        public async Task<bool> DeleteOrderById(int id)
        {
            return await _orderService.DeleteOrderById(id);
        }
    }
}
