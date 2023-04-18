using CeeStore.BLL.ServicesContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CeeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;        

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;            
        }

        [HttpPost("verify-payment")]
        public async Task<IActionResult> VerifyPayment([FromBody] string referenceCode)
        {
            var response = _paymentService.MakePayment(referenceCode);

            return Ok(response);
        }
    }
}
