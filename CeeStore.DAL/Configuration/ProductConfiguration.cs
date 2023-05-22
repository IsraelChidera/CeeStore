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
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-5.jpg",
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
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-5.jpg",
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
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749326/samples/people/boy-snow-hoodie.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Electric Iron",
                    Description = "Dry Electric Iron - DII255",
                    Price = 5800,
                    Quantity = 10,
                    BrandName = "DII255",
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749330/samples/ecommerce/accessories-bag.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Plain Tshirt",
                    Description = "Legends are born in March premium class T-shirt",
                    Price = 5000,
                    Quantity = 10,
                    BrandName = "Xcrux",
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749330/samples/ecommerce/accessories-bag.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Plain Men's T-shirts Combo of 3",
                    Description = "Loius Vuitton Beenie (red, yellow, black)",
                    Price = 6500,
                    Quantity = 10,
                    BrandName = "Grey Tshirt Store",
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749329/samples/ecommerce/leather-bag-gray.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Nivea Perfect & Radiant",
                    Description = "NIVEA Perfect & Radiant 3 In 1 Face Cleanser " +
                    "For Women - 150ml",
                    Price = 15000,
                    Quantity = 10,
                    BrandName = "Nivea",
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749329/samples/ecommerce/leather-bag-gray.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Jameson Black",
                    Description = "Jameson Black Barrel 7",
                    Price = 16085,
                    Quantity = 10,
                    BrandName = "Jameson Black",
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749330/samples/ecommerce/accessories-bag.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Coca-cola",
                    Description = "Coca-cola Drink - 50cl P",
                    Price = 1900,
                    Quantity = 10,
                    BrandName = "Coca-cola",
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749330/samples/ecommerce/accessories-bag.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Absolut Vodka",
                    Description = "Absolut Vodka Vanilla 1L",
                    Price = 6000,
                    Quantity = 5,
                    BrandName = "Absolut",
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-4.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Maltina Classic",
                    Description = "Maltina Classic Can 33CL",
                    Price = 5400,
                    Quantity = 24,
                    BrandName = "Maltina",
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-4.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Harpic Cleaner",
                    Description = "Harpic Toilet Cleaner: M",
                    Price = 1800,
                    Quantity = 14,
                    BrandName = "Harpic",
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-4.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Monster drink",
                    Description = "Monster Can Green 44cl",
                    Price = 11000,
                    Quantity = 14,
                    BrandName = "Monster",
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-4.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Jameson Whiskey",
                    Description = "Jameson Irish Whiskey",
                    Price = 10500,
                    Quantity = 10,
                    BrandName = "Jameson",
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-4.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "New balance sneakers",
                    Description = "White soled, high new balance",
                    Price = 15000,
                    Quantity = 10,
                    BrandName = "New Balance",
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-5.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                },
                new Product()
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = "Air Jordan II",
                    Description = "White Air Jordan II",
                    Price = 55500,
                    Quantity = 10,
                    BrandName = "Nike",
                    ProductImage = "https://res.cloudinary.com/dcphruz6h/image/upload/v1684749344/cld-sample-5.jpg",
                    UserId = new Guid("06dd95bf-2c94-4e3d-8424-57d912f135d7")
                }
            );
        }
    }
}
