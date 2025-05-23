﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace E_commerce.Models.context
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

     
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShippingAddress> ShippingAddresses { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }

}
