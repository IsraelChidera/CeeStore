using CeeStore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.BLL.ServicesContract
{
    public interface IProductService
    {
        Task<string> CreateProductAsync(CreatePrductRequestDto productRequest);
        Task<string> UpdateProductAsync(Guid productId, CreatePrductRequestDto productRequest);

        Task<List<CreatePrductRequestDto>> GetProduct(SearchTermDto searchProductRequest);

        Task<IEnumerable<CreatePrductRequestDto>> GetAllProducts();

        Task<List<ProductResponseDto>> GetSellerProduct();

        Task<string> DeleteProduct(Guid productId);
        
    }
}
