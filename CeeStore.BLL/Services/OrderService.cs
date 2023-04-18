using AutoMapper;
using CeeStore.BLL.ServicesContract;
using CeeStore.DAL.Entities;
using CeeStore.DAL.Enums;
using CeeStore.DAL.Repository;
using CeeStore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PayStack.Net;
using System.Security.Claims;

namespace CeeStore.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Cart> _cartRepo;
        private readonly IRepository<Orders> _ordersRepo;
        private readonly IRepository<OrderItem> _ordersItemRepo; 
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        

        public OrderService(IConfiguration config, IHttpContextAccessor httpContextAccessor, IMapper mapper,
            UserManager<AppUser> userManager, IUnitOfWork unitOfWork
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _config = config;                     
            _mapper = mapper;            
            _ordersRepo = _unitOfWork.GetRepository<Orders>();
            _ordersItemRepo = _unitOfWork.GetRepository<OrderItem>();
            _cartRepo = _unitOfWork.GetRepository<Cart>();
           
            
        }

        public async Task<string> CheckoutAsync(Guid cartId, ShippingMethod shippingMethod)
        {
            var cartExists = await _cartRepo.GetSingleByAsync(ce => ce.CartId == cartId,
                include: ci => ci.Include(c => c.CartItems)
                .ThenInclude(c => c.Product)
                );

            if (cartExists is null)
            {
                throw new Exception("cart not found");
            }

            if (!cartExists.CartItems.Any() || cartExists.CartItems is null)
            {
                return "Cart is empty";
            }

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var buyer = await _userManager.FindByIdAsync(userId);

            if (buyer is null)
            {
                throw new Exception("buyer is not found");
            }

            var orderReference = GenerateReference();

            var order = new Orders
            {
                UserId = Guid.Parse(buyer.Id),
                Reference = orderReference,
                OrderDate = DateTime.UtcNow,
                OrderStatus = OrderStatus.Pending,

            };

            var (shippingCost, estimatedDeliveryDate) = await CalculateShippingAsync(shippingMethod);

            order.ShippingCost = shippingCost;
            order.EstimateDeliveryDate = estimatedDeliveryDate;
            order.shippingmethod = shippingMethod.ToString();

            order.TotalAmount = cartExists.CartItems.Sum(ci => ci.Product.Price * ci.Quantity) + shippingCost;

            await _ordersRepo.AddAsync(order);

            var orderItems = cartExists.CartItems.Select(
                ci => new OrderItem
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    Price = ci.Product.Price,
                    OrdersId = Guid.Parse(order.OrdersId.ToString())
                }
            ).ToList();

            await _ordersItemRepo.AddRangeAsync(orderItems);
            await _cartRepo.DeleteAsync(cartExists);

            var payment = new PaymentRequestDto
            {
                Amount = order.TotalAmount,
                Email = buyer.Email,
                PaymentReference = orderReference,
                CallbackUrl = "https://localhost:5100/ceestore/Products/verifypayment"
            };
            //map the above to a payment table
            var transaction = await MakePayment(payment);
            //or map the above to a payment entity
            order.TransactionReference = transaction.Data.Reference;
            order.PaymentGateway = "Paystack Payment Gateway";
            order.OrderStatus = OrderStatus.PendingPayment;

            await _ordersRepo.UpdateAsync(order);


            return $"Payment initiated for {buyer.UserName}'s order";
        }

        public async Task<TransactionInitializeResponse> MakePayment(PaymentRequestDto paymentRequest)
        {
            var secretpaymentkey = _config.GetSection("Payment").GetSection("PaystackTestKey").Value;

            PayStackApi paystack = new(secretpaymentkey);

            TransactionInitializeRequest createRequest = new()
            {
                Email = paymentRequest.Email,
                AmountInKobo = (int)(paymentRequest.Amount * 100),
                Currency = "NGN",
                Reference = paymentRequest.PaymentReference,
                CallbackUrl = paymentRequest.CallbackUrl
            };

            TransactionInitializeResponse response = paystack.Transactions.Initialize(createRequest);
            var authorizationUrl = response.Data.AuthorizationUrl;
            _httpContextAccessor.HttpContext.Response.Redirect(authorizationUrl);

            return response;
        }


        public static string GenerateReference()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            var getRandom = rand.Next(100000000, 999999999);

            return $"#Cee-{getRandom}";
        }

        public static async Task<(decimal shippingCost, DateTime estimatedDeliveryDate)> CalculateShippingAsync(ShippingMethod shippingMethod)
        {
            decimal shippingCost = 0;
            DateTime estimatedDeliveryDate = DateTime.UtcNow;

            switch (shippingMethod)
            {
                case ShippingMethod.Express:
                    shippingCost = 50m;
                    estimatedDeliveryDate = estimatedDeliveryDate.AddDays(3);
                    break;
                case ShippingMethod.NextDay:
                    shippingCost += 100m;
                    estimatedDeliveryDate = estimatedDeliveryDate.AddDays(1);
                    break;
                default:
                    shippingCost = 0;
                    estimatedDeliveryDate = estimatedDeliveryDate.AddDays(5);
                    break;

            }

            return (shippingCost, estimatedDeliveryDate);

        }

    }
}
