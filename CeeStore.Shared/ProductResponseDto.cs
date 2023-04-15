using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.Shared
{
    public class ProductResponseDto
    {
        [MinLength(3)]
        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }

        [MinLength(8)]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Brand name is required")]
        public string BrandName { get; set; }
    }
}
