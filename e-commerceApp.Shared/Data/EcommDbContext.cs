

using e_commerceApp.Shared.Models;
using e_commerceApp.Shared.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace e_commerceApp.Shared.Data
{
    public class EcommDbContext : IdentityDbContext<User>
    {
        public EcommDbContext(DbContextOptions<EcommDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRole(builder);
        }

        private void SeedRole(ModelBuilder builder)
        {
            var adminRoleId = "64ef6773-7c32-42d4-afa3-ab21eb048c9a";
            var userRoleId = "79eb8bf1-28ba-4a65-a828-19520956f0fd";
            //create a role
            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    ConcurrencyStamp = adminRoleId,
                    NormalizedName = "Admin".ToUpper(),
                },
                new IdentityRole
                {
                    Id = userRoleId,
                    Name = "User",
                    ConcurrencyStamp = userRoleId,
                    NormalizedName = "User".ToUpper(),
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
