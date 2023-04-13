using System.ComponentModel.DataAnnotations;

namespace CeeStore.Shared
{
    public class CreatePrductRequestDto
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
