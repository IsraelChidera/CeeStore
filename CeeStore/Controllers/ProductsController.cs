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
        [HttpPost("update-a-product")]
        public async Task<IActionResult> UpdateProduct(Guid productId, CreatePrductRequestDto productRequest)
        {
            var response = await _productService.UpdateProductAsync(productId, productRequest);
            return Ok(response);
        }

    }
}
