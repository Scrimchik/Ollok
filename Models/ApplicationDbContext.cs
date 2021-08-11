using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ollok.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().Property(t => t.IsSeen).HasDefaultValue(true);
            builder.Entity<Order>().Property(t => t.Status).HasDefaultValue("В ожидании");
            builder.Entity<Order>().Property(t => t.Time).HasDefaultValue(DateTime.Now);
        }
    }
}
