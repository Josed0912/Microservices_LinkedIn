using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsProvider orderItemsProvider;

        public OrderItemsController(IOrderItemsProvider orderItemsProvider)
        {
            this.orderItemsProvider = orderItemsProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderItemsAsync()
        {
            var result = await orderItemsProvider.GetOrderItemsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.OrderItems);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemAsync(int id)
        {
            var result = await orderItemsProvider.GetOrderItemAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.OrderItem);
            }
            return NotFound();
        }
    }
}
