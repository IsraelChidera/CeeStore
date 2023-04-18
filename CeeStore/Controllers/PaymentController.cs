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
        private readonly ILoggerManager _logger;

        public PaymentController(IPaymentService paymentService, ILoggerManager logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [HttpPost("verify-payment")]
        public async Task<IActionResult> VerifyPayment([FromBody] string referenceCode)
        {
            var response = _paymentService.MakePayment(referenceCode);

            return Ok(response);
        }
    }
}
