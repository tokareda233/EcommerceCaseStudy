using EcommerceCaseStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCaseStudy.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<User> users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);


            modelBuilder.Entity<User>()
               .HasMany(c => c.Orders)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Order>()
               .HasMany(c => c.orderItems)
               .WithOne(c => c.Order)
               .HasForeignKey(c => c.OrderId);

            modelBuilder.Entity<Product>()
               .HasMany(c => c.orderItems)
               .WithOne(c => c.Product)
               .HasForeignKey(c => c.ProductId);
        }
    }
}
