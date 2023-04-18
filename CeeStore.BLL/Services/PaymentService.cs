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
        private readonly IRepository<Wallet> _walletRepo;
        private readonly IRepository<Orders> _ordersRepo;
        private readonly IRepository<OrderItem> _ordersItemRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerManager _logger;

        public PaymentService(IConfiguration config, IMapper mapper, UserManager<AppUser> userManager, IRepository<Orders> ordersRepo,
            IUnitOfWork unitOfWork, ILoggerManager logger)
        {
            _config = config;
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _walletRepo = _unitOfWork.GetRepository<Wallet>();
            _ordersRepo = _unitOfWork.GetRepository<Orders>();
            _ordersItemRepo = _unitOfWork.GetRepository<OrderItem>();
            _logger = logger;
        }

        public async Task<string> MakePayment(string referenceCode)
        {
            string secretpaymentkey = _config.GetSection("Payment").GetSection("PaystackTestKey").Value;

            PayStackApi paystack = new(secretpaymentkey);

            TransactionVerifyResponse response = paystack.Transactions.Verify(referenceCode);

            if (response.Status)
            {
                var orderExists = await _ordersRepo.GetSingleByAsync(oe => oe.TransactionReference == referenceCode);

                if (orderExists != null)
                {
                    var orderItemExists = await _ordersItemRepo.GetSingleByAsync(
                        oie => oie.OrderId == orderExists.OrdersId, include: oie => oie.Include(i => i.Product)
                        .ThenInclude(i => i.UserId.ToString())
                    );

                    var sellerWallet = await _walletRepo.GetSingleByAsync(w => w.UserId == orderItemExists.Product.UserId);
                    if (sellerWallet != null)
                    {
                        sellerWallet.Balance += orderExists.TotalAmount;
                        orderExists.OrderStatus = OrderStatus.Paid;

                        await _walletRepo.UpdateAsync(sellerWallet);
                        await _ordersRepo.UpdateAsync(orderExists);

                        return "Payment made successfully";
                    }

                }


            }

            return "Unable to make payment";


        }
    }
}
