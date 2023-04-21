using CeeStore.BLL.Services;
using CeeStore.BLL.ServicesContract;
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
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = "Buyer, SuperAdmin, Admin")]
        [HttpPost("cart/checkout")]        
        public async Task<IActionResult> BuyersCheckout(Guid cartId, ShippingMethod shippingMethod)
        {
            await _orderService.CheckoutAsync(cartId, shippingMethod);
            return Ok();
        }
    }
}
