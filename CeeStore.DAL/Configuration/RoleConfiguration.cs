using CeeStore.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.DAL.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Buyer",
                    NormalizedName = "BUYER"
                },
                new IdentityRole
                {
                    Name = "Seller",
                    NormalizedName = "SELLER"
                }
            );
        }

        public void Seed(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                };

                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Seller").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Seller",
                    NormalizedName = "SELLER"
                };

                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Buyer").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Buyer",
                    NormalizedName = "BUYER"
                };

                var result = roleManager.CreateAsync(role).Result;
            }


        }


    }
}
