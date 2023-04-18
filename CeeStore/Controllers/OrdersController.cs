using CeeStore.BLL.Services;
using CeeStore.DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CeeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = "Buyer")]
        [HttpPost("cart/checkout")]        
        public async Task<IActionResult> BuyersCheckout(Guid carId, ShippingMethod shippingMethod)
        {
            await _orderService.CheckoutAsync(carId, shippingMethod);
            return Ok();
        }
    }
}
