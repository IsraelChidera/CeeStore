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
                    ProductName = "Electric Iron",
                    Description = "Dry Electric Iron - DII255",
                    Price = 5800,
                    Quantity = 10,
                    BrandName = "DII255",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"),
                    ProductName = "Plain Tshirt",
                    Description = "Legends are born in March premium class T-shirt",
                    Price = 5000,
                    Quantity = 10,
                    BrandName = "Xcrux",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"),
                    ProductName = "Plain Men's T-shirts Combo of 3",
                    Description = "Loius Vuitton Beenie (red, yellow, black)",
                    Price = 6500,
                    Quantity = 10,
                    BrandName = "Grey Tshirt Store",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"),
                    ProductName = "Nivea Perfect & Radiant",
                    Description = "NIVEA Perfect & Radiant 3 In 1 Face Cleanser " +
                    "For Women - 150ml",
                    Price = 15000,
                    Quantity = 10,
                    BrandName = "Nivea",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"),
                    ProductName = "Jameson Black",
                    Description = "Jameson Black Barrel 7",
                    Price = 16085,
                    Quantity = 10,
                    BrandName = "Jameson Black",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"),
                    ProductName = "Coca-cola",
                    Description = "Coca-cola Drink - 50cl P",
                    Price = 1900,
                    Quantity = 10,
                    BrandName = "Coca-cola",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"),
                    ProductName = "Absolut Vodka",
                    Description = "Absolut Vodka Vanilla 1L",
                    Price = 6000,
                    Quantity = 5,
                    BrandName = "Absolut",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"),
                    ProductName = "Maltina Classic",
                    Description = "Maltina Classic Can 33CL",
                    Price = 5400,
                    Quantity = 24,
                    BrandName = "Maltina",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"),
                    ProductName = "Harpic Cleaner",
                    Description = "Harpic Toilet Cleaner: M",
                    Price = 1800,
                    Quantity = 14,
                    BrandName = "Harpic",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"),
                    ProductName = "Monster drink",
                    Description = "Monster Can Green 44cl",
                    Price = 11000,
                    Quantity = 14,
                    BrandName = "Monster",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = new Guid("c3e3c66c-c1d6-46f9-a725-9f24049652fd"),
                    ProductName = "Jameson Whiskey",
                    Description = "Jameson Irish Whiskey",
                    Price = 10500,
                    Quantity = 10,
                    BrandName = "Jameson",
                    ProductImage = "",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                }
            );
        }
    }
}
