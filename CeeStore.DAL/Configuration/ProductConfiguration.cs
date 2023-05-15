using CeeStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.DAL.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product()
                {
                    ProductId = new Guid("91c22eb3-8e1c-4a39-bd5f-299dcad5c4c1"),
                    ProductName= "Vintage wears",
                    Description= "Multi-colored vintage wears",
                    Price = 12500,
                    Quantity = 10,
                    BrandName = "Xivex Wears",
                    ProductImage = "",
                    UserId= new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("835bb68d-9e09-4b81-b1ed-3925a1db68af"),
                    ProductName = "Arsenal T-shirt",
                    Description = "Red Arsenal T-shirt of all sizes (S,M,L,Xl,XXL)",
                    Price = 8500,
                    Quantity = 8,
                    BrandName = "Glover Sport Wears",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"),
                    ProductName = "Spring Hoodie",
                    Description = "Black winter hoodies (S,M,L,Xl,XXL)",
                    Price = 14500,
                    Quantity = 5,
                    BrandName = "X-G",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"),
                    ProductName = "LV Beenie",
                    Description = "Loius Vuitton Beenie (red, yellow, black)",
                    Price = 25000,
                    Quantity = 20,
                    BrandName = "LV",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"),
                    ProductName = "LV Beenie",
                    Description = "Loius Vuitton Beenie (red, yellow, black)",
                    Price = 25000,
                    Quantity = 20,
                    BrandName = "LV",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                }
            );
        }
    }
}
