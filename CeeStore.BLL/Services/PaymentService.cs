using AutoMapper;
using CeeStore.BLL.ServicesContract;
using CeeStore.DAL.Entities;
using CeeStore.DAL.Enums;
using CeeStore.DAL.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PayStack.Net;

namespace CeeStore.BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _config;        
        private readonly IRepository<Orders> _ordersRepo;
        private readonly IRepository<OrderItem> _ordersItemRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;

        public PaymentService(IConfiguration config, IMapper mapper, UserManager<AppUser> userManager,
            IUnitOfWork unitOfWork, ILoggerManager logger)
        {
            _unitOfWork = unitOfWork;
            _config = config;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;            
            _ordersRepo = _unitOfWork.GetRepository<Orders>();
            _ordersItemRepo = _unitOfWork.GetRepository<OrderItem>();
            _logger = logger;
        }

        public async Task<string> MakePayment(string referenceCode)
        {
            throw new NotImplementedException();

        }
    }
}
