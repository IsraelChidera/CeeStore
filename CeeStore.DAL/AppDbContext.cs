using CeeStore.DAL.Configuration;
using CeeStore.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CeeStore.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration());
            base.OnModelCreating(builder);

            /*builder.Entity<Product>(e =>
            {
                e.Property(p => p.Price).HasPrecision(18, 2);

                builder.Entity<CartItem>()
               .HasOne(ci => ci.Product)
               .WithMany()
               .HasForeignKey(ci => ci.ProductId)
               .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<CartItem>(entity =>
            {
                entity.HasOne(ci => ci.Product)
                      .WithMany()
                      .HasForeignKey(ci => ci.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });*/


        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Orders> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Wallet> Wallet { get; set; }

    }
}
