using AutoMapper;
using CeeStore.BLL.ServicesContract;
using CeeStore.DAL.Entities;
using CeeStore.DAL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CeeStore.BLL.Services
{
    public class OrderService:IOrderService
    {
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Cart> _cartRepo;
        private readonly IRepository<Orders> _ordersRepo;
        private readonly IRepository<OrderItem> _ordersItemRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;

        public OrderService(IConfiguration config, IHttpContextAccessor httpContextAccessor, IMapper mapper,
            UserManager<AppUser> userManager, ILoggerManager logger, IUnitOfWork unitOfWork
            )
        {
            _config = config;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _ordersRepo = _unitOfWork.GetRepository<Orders>();
            _ordersItemRepo = _unitOfWork.GetRepository<OrderItem>();
            _cartRepo = _unitOfWork.GetRepository<Cart>();
            _productRepo = _unitOfWork.GetRepository<Product>();
            _userManager = userManager;
        }

        public async Task<string> CheckoutAsync(Guid carId)
        {
            var cartExists = await _cartRepo.GetSingleByAsync(ce=>ce.CartId== carId,
                include:ci =>ci.Include(c=>c.CartItems)
                .ThenInclude(c=>c.Product)
                );

            if(cartExists is null)
            {
                throw new Exception("cart not found");
            }

            return "";
        }
    }
}
