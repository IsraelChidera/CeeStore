using CeeStore.BLL.ServicesContract;
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


        [Authorize(Roles = "Seller, SuperAdmin, Admin")]
        [HttpPost("create-a-product")]
        public async Task<IActionResult> CreateProduct(CreatePrductRequestDto productRequest)
        {
            var response = await _productService.CreateProductAsync(productRequest);
            return Ok(response);
        }


        [Authorize(Roles = "Seller, SuperAdmin, Admin")]
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



        [Authorize(Roles = "Seller, SuperAdmin, Admin")]
        [HttpGet("get-seller-products")]
        public async Task<ActionResult<List<ProductResponseDto>>> GetSellerProducts()
        {
            var reponse = await _productService.GetSellerProductAsync();

            return Ok(reponse);
        }



        [Authorize(Roles = "Seller, SuperAdmin, Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var response = await _productService.DeleteProductAsync(productId);
            return NoContent();
        }



        [Authorize(Roles = "Seller, Buyer, SuperAdmin, Admin")]
        [HttpPost("add-to-cart")]
        public async Task<IActionResult> AddToCart(Guid productId, int quantity)
        {
            var response = await _productService.AddToCartAsync(productId, quantity);

            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Failed to add product to cart");
        }


        [AllowAnonymous]
        [HttpGet("get-a-product")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var response = await _productService.GetProductById(productId);

            return Ok(response);
        }

    }
}
