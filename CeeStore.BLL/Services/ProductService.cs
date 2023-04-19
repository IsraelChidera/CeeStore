﻿using AutoMapper;
using CeeStore.BLL.ServicesContract;
using CeeStore.DAL.Entities;
using CeeStore.DAL.Repository;
using CeeStore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CeeStore.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Seller> _sellerRepo;
        private readonly IRepository<Buyer> _buyerRepo;
        private readonly IRepository<Cart> _cartRepo;
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
            _buyerRepo = _unitOfWork.GetRepository<Buyer>();
            _cartRepo = _unitOfWork.GetRepository<Cart>();
        }

        public async Task<string> AddToCartAsync(Guid productId, int quantity)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var buyer = await _userManager.FindByIdAsync(userId);
                if (buyer is null)
                {
                    throw new Exception("Buyer not found");
                }

                var product = await _productRepo.GetByIdAsync(productId);

                if (product is null)
                {
                    throw new Exception("Product is not found");
                }

                if (quantity <= 0)
                {
                    throw new ArgumentException("Invalid quantity");
                }

                var cart = await _cartRepo.GetSingleByAsync(c => c.UserId == Guid.Parse(buyer.Id),
                    include: i => i.Include(c => c.CartItems));

                if (cart is null)
                {
                    cart = new Cart { UserId = Guid.Parse(buyer.Id) };
                    await _cartRepo.AddAsync(cart);
                }

                if (cart.CartItems is null)
                {
                    cart.CartItems = new List<CartItem>();
                }

                var cartItem = cart.CartItems.FirstOrDefault(c => c.ProductId == productId);

                if (cartItem is not null)
                {
                    cartItem.Quantity += quantity;
                }
                cartItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity
                };
                cart.CartItems.Add(cartItem);

                await _cartRepo.UpdateAsync(cart);
                await _unitOfWork.SaveChangesAsync();
                return $"{product.ProductName} added to cart successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                throw new Exception(ex.Source);
            }
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

            if (seller == null)
            {
                throw new Exception("Seller not found in database");
            }

            productMapped.UserId = Guid.Parse(seller.Id);

            await _productRepo.AddAsync(productMapped);
            await _unitOfWork.SaveChangesAsync();

            return "Congratulations! \nYou have successfully added a new product";

        }

        public async Task<string> DeleteProductAsync(Guid productId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null)
            {
                throw new Exception("user not found");
            }

            var seller = await _userManager.FindByIdAsync(userId);

            var productExists = await _productRepo.GetSingleByAsync(p => p.ProductId == productId);
            if (productExists is null)
            {
                throw new Exception("Product does not exist");
            }

            await _productRepo.DeleteAsync(productExists);

            return "Product deleted successfully";
        }

        public async Task<IEnumerable<CreatePrductRequestDto>> GetAllProductsAsync()
        {
            var allProducts = await _productRepo.GetAllAsync();

            var products = _mapper.Map<List<CreatePrductRequestDto>>(allProducts);

            return products;
        }

        public async Task<List<CreatePrductRequestDto>> GetProductAsync(SearchTermDto searchProductRequest)
        {
            var allProducts = await _productRepo.GetAllAsync();

            if (!string.IsNullOrEmpty(searchProductRequest.Search))
            {
                allProducts = allProducts.Where(p => p.ProductName.Contains(searchProductRequest.Search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            var result = _mapper.Map<List<CreatePrductRequestDto>>(allProducts);
            return result;

        }

        public async Task<List<ProductResponseDto>> GetSellerProductAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId is null)
            {
                throw new Exception("User not found");
            }

            AppUser seller = await _userManager.FindByIdAsync(userId);

            if (seller is null)
            {
                throw new Exception("user is not found");
            }

            var product = _productRepo.GetQueryable(p => p.UserId.ToString() == seller.Id.ToString());

            var result = _mapper.Map<List<ProductResponseDto>>(product);

            return result;
        }

        public async Task<string> UpdateProductAsync(Guid productId, CreatePrductRequestDto productRequest)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            if (userId is null)
            {
                throw new Exception("User not found");
            }

            Product productExists = await _productRepo.GetSingleByAsync(p => p.ProductId == productId);

            if (productExists is null)
            {
                throw new Exception("Product does not exist");
            }

            /*  if (productExists.UserId.ToString() == userId.ToString())
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
