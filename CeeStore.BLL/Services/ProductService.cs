using AutoMapper;
using CeeStore.BLL.ServicesContract;
using CeeStore.DAL.Entities;
using CeeStore.DAL.Repository;
using CeeStore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CeeStore.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Seller> _sellerRepo;
        private readonly ILoggerManager _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public ProductService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, ILoggerManager logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _productRepo = _unitOfWork.GetRepository<Product>();
            _sellerRepo = _unitOfWork.GetRepository<Seller>();
        }

        public async Task<string> CreateProductAsync(CreatePrductRequestDto productRequest)
        {

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                throw new Exception("User not authenticated");
            }

            var productMapped = _mapper.Map<Product>(productRequest);

            var seller = await _userManager.FindByIdAsync(userId);
            //Seller seller = await _sellerRepo.GetSingleByAsync(s => s.UserId.ToString() == userId.ToString());

            if (seller == null)
            {
                throw new Exception("Seller not found in database");
            }

            productMapped.UserId = Guid.Parse(seller.Id);
            //productMapped.SellerId = seller;

            await _productRepo.AddAsync(productMapped);
            await _unitOfWork.SaveChangesAsync();

            return "Congratulations! \nYou have successfully added a new product";

        }

        public async Task<string> UpdateProductAsync(Guid productId, CreatePrductRequestDto productRequest)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            if(userId is null)
            {
                throw new Exception("User not found");
            }

            Product productExists = await _productRepo.GetSingleByAsync(p=>p.ProductId == productId);
            
            if(productExists is null)
            {
                throw new Exception("Product does not exist");
            }

         /*   if(productExists.UserId != userId)
            {
                throw new Exception("You do not have the permission to update this product");
            }*/

            var product = _mapper.Map(productRequest, productExists);

            await _productRepo.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return "Product updated successfully";
        }

    }
}
