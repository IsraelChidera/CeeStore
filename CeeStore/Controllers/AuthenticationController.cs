using CeeStore.BLL.ServicesContract;
using CeeStore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CeeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService= authenticationService;
        }

        [HttpPost]
        [Route("Register-as-a-buyer")]
        public async Task<IActionResult> CreateBuyer(BuyerForRegistrationDto buyer)
        {
            var result = await _authenticationService.RegisterBuyerAsync(buyer);

            return Ok(result);
        }
    }
}
