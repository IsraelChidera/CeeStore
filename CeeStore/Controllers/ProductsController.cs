﻿using CeeStore.BLL.ServicesContract;
using CeeStore.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CeeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [Authorize(Roles = "Seller")]
        [HttpPost("create-a-product")]
        public async Task<IActionResult> CreateProduct(CreatePrductRequestDto productRequest)
        {
            var response = await _productService.CreateProductAsync(productRequest);
            return Ok(response);
        }

        [Authorize(Roles = "Seller")]
        [HttpPut("update-a-product")]
        public async Task<IActionResult> UpdateProduct(Guid productId, CreatePrductRequestDto productRequest)
        {
            var response = await _productService.UpdateProductAsync(productId, productRequest);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("search-products")]
        public async Task<ActionResult<List<CreatePrductRequestDto>>> GetProducts([FromQuery] SearchTermDto searchProductRequest)
        {
            var response = await _productService.GetProductAsync(searchProductRequest);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("all-products")]
        public async Task<ActionResult<IEnumerable<CreatePrductRequestDto>>> GetAllProducts()
        {
            var response = await _productService.GetAllProductsAsync();
            return Ok(response);
        }

        [Authorize(Roles = "Seller")]
        [HttpGet("get-seller-products")]
        public async Task<ActionResult<List<ProductResponseDto>>> GetSellerProducts()
        {
            var reponse = await _productService.GetSellerProductAsync();

            return Ok(reponse);
        }

        [Authorize(Roles = "Seller")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var response = await _productService.DeleteProductAsync(productId);
            return NoContent();
        }

    }
}
