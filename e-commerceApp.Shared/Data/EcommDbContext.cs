

using e_commerceApp.Shared.Models;
using e_commerceApp.Shared.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace e_commerceApp.Shared.Data
{
    public class EcommDbContext : IdentityDbContext<User, Role, int>
    {
        public EcommDbContext(DbContextOptions<EcommDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderDetail>()
              .HasOne(od => od.OrderHeader) 
              .WithMany(oh => oh.OrderDetails)
              .HasForeignKey(od => od.OrderHeaderId) 
              .OnDelete(DeleteBehavior.Restrict);

            SeedRole(builder);
            builder.GenerateSeed();
        }

        private void SeedRole(ModelBuilder builder)
        {
            //create a role
            builder.Entity<Role>().HasData(
                new Role
                { Id = 1, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
                new Role
                { Id = 2, Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString() });
        }

    }
}
