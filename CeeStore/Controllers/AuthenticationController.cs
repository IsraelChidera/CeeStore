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
        [Route("register-as-a-buyer")]
        public async Task<IActionResult> CreateBuyer(BuyerForRegistrationDto buyer)
        {
            var result = await _authenticationService.RegisterBuyerAsync(buyer);

            return Ok(result);
        }

        [HttpPost]
        [Route("register-as-a-seller")]
        public async Task<IActionResult> CreateSeller(SellerForRegistrationDto seller)
        {
            var result = await _authenticationService.RegisterSellerAsync(seller);
            return Ok(result);
        }

        [HttpPost]
        [Route("register-as-an-admin")]
        public async Task<IActionResult> CreateAdmin(AdminForRegistrationDto admin)
        {
            var result = await _authenticationService.RegisterAdminAsync(admin);
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto user)
        {
            var response = await _authenticationService.ValidateUser(user);

            if (!response)
                return BadRequest(response);

            return Ok(new { Token = await _authenticationService.CreateToken() });
        }

    }
}
