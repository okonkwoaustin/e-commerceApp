using e_commerceApp.Shared.Enum;
using e_commerceApp.Shared.Models;
using e_commerceApp.Shared.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace e_commerceApp.Shared
{
    public static class DbInitializer
    {


        public static void GenerateSeed(this ModelBuilder modelBuilder)
        {
            var userIds = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var categoryIds = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var productIds = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var orderHeaderIds = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var orderDetailIds = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var cartIds = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var shoppingCartItemIds = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            var reviewIds = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };



                    modelBuilder.Entity<User>().HasData(
             new User { Id = userIds[0].ToString(), FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", UserName = "john.doe@example.com", PhoneNumber = "123456-7890", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
             new User { Id = userIds[1].ToString(), FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", UserName = "jane.smith@example.com", PhoneNumber = "9876543210", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
             new User { Id = userIds[2].ToString(), FirstName = "Ike", LastName = "Sunny", Email = "ike.sunny@example.com", UserName = "ike.sunny@example.com", PhoneNumber = "4567891234", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
             new User { Id = userIds[3].ToString(), FirstName = "Adam", LastName = "Jane", Email = "adam.jane@example.com", UserName = "adam.jane@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
             new User { Id = userIds[4].ToString(), FirstName = "Ronald", LastName = "Smith", Email = "ronald.smith@example.com", UserName = "ronald.smith@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
             new User { Id = userIds[5].ToString(), FirstName = "Gate", LastName = "Paulo", Email = "gate.paulo@example.com", UserName = "gate.paulo@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
             new User { Id = userIds[6].ToString(), FirstName = "Lurge", LastName = "Luck", Email = "lurge.luck@example.com", UserName = "lurge.luck@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
             new User { Id = userIds[7].ToString(), FirstName = "Bana", LastName = "Good", Email = "bana.good@example.com", UserName = "bana.good@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
             new User { Id = userIds[8].ToString(), FirstName = "Matt", LastName = "Paul", Email = "matt.paul@example.com", UserName = "matt.paul@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
             new User { Id = userIds[9].ToString(), FirstName = "John", LastName = "Matt", Email = "john.matt@example.com", UserName = "john.matt@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
             new User { Id = userIds[10].ToString(), FirstName = "Joan", LastName = "Mark", Email = "joan.mark@example.com", UserName = "joan.mark@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
         );

                modelBuilder.Entity<Category>().HasData(
             new Category { Id = categoryIds[0].ToString(), Name = "Phone" },
             new Category { Id = categoryIds[1].ToString(), Name = "Laptop" },
             new Category { Id = categoryIds[2].ToString(), Name = "Charger" },
             new Category { Id = categoryIds[3].ToString(), Name = "Earpiece" },
             new Category { Id = categoryIds[4].ToString(), Name = "Tablet" },
             new Category { Id = categoryIds[5].ToString(), Name = "Headphones" },
             new Category { Id = categoryIds[6].ToString(), Name = "Smartwatch" },
             new Category { Id = categoryIds[7].ToString(), Name = "Accessories" },
             new Category { Id = categoryIds[8].ToString(), Name = "Gaming" },
             new Category { Id = categoryIds[9].ToString(), Name = "Fashion" },
             new Category { Id = categoryIds[10].ToString(), Name = "Home Appliances" }
         );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = productIds[0].ToString(), Title = "Product 1", Description = "Description of Product 1", Price = 170000, StockQuantity = 100, CartegoryId = categoryIds[0].ToString(), CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.Availble, ImageUrl = "https://example.com/images/product1.jpg" },
                new Product { Id = productIds[1].ToString(), Title = "Product 2", Description = "Description of Product 2", Price = 295000, StockQuantity = 50, CartegoryId = categoryIds[1].ToString(), CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.Availble, ImageUrl = "https://example.com/images/product2.jpg" },
                new Product { Id = productIds[2].ToString(), Title = "Product 3", Description = "Description of Product 3", Price = 49500, StockQuantity = 40, CartegoryId = categoryIds[2].ToString(), CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.Discontinued, ImageUrl = "https://example.com/images/product3.jpg" },
                new Product { Id = productIds[3].ToString() , Title = "Product 4", Description = "Description of Product 4", Price = 50000, StockQuantity = 500, CartegoryId = categoryIds[3].ToString(), CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product4.jpg" },
                new Product { Id = productIds[4].ToString(), Title = "Product 5", Description = "Description of Product 5", Price = 900000, StockQuantity = 700, CartegoryId = categoryIds[4].ToString(), CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product5.jpg" },
                new Product { Id = productIds[5].ToString(), Title = "Product 6", Description = "Description of Product 6", Price = 856000, StockQuantity = 900, CartegoryId = categoryIds[5].ToString(), CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product6.jpg" },
                new Product { Id = productIds[6].ToString(), Title = "Product 7", Description = "Description of Product 7", Price = 7000m, StockQuantity = 80, CartegoryId = categoryIds[6].ToString(), CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product7.jpg" },
                new Product { Id = productIds[7].ToString(), Title = "Product 8", Description = "Description of Product 8", Price = 25000, StockQuantity = 800, CartegoryId = categoryIds[7].ToString(), CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product8.jpg" },
                new Product { Id = productIds[8].ToString(), Title = "Product 9", Description = "Description of Product 9", Price = 780000, StockQuantity = 700, CartegoryId = categoryIds[8].ToString(), CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product9.jpg" },
                new Product { Id = productIds[9].ToString(), Title = "Product 10", Description = "Description of Product 10", Price = 56000, StockQuantity = 700, CartegoryId = categoryIds[9].ToString(), CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product10.jpg" },
                new Product { Id = productIds[10].ToString(), Title = "Product 11", Description = "Description of Product 11", Price = 45000, StockQuantity = 600, CartegoryId = categoryIds[10].ToString(), CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product11.jpg" }
            );

            modelBuilder.Entity<OrderHeader>().HasData(
                new OrderHeader { Id = orderHeaderIds[0].ToString(), UserId = userIds[0].ToString(), OrderDate = DateTime.UtcNow.AddDays(-10), ShippingDate = DateTime.UtcNow.AddDays(-5), TotalPrice = 9999, OrderStatus = "Shipped", PaymentStatus = "Paid", PhoneNumber = "1234567890", StreetAddress = "123 Main St", City = "City A", State = "Agege", PostalCode = "12345", Name = "John Doe" },
                new OrderHeader { Id = orderHeaderIds[1].ToString(), UserId = userIds[1].ToString(), OrderDate = DateTime.UtcNow.AddDays(-8), ShippingDate = DateTime.UtcNow.AddDays(-4), TotalPrice = 19999, OrderStatus = "Delivered", PaymentStatus = "UnPaid", PhoneNumber = "98789943210", StreetAddress = "86 Oak St", City = "City B", State = "Ajah", PostalCode = "67890", Name = "Jane Sunny" },
                new OrderHeader { Id = orderHeaderIds[2].ToString(), UserId = userIds[2].ToString(), OrderDate = DateTime.UtcNow.AddDays(-9), ShippingDate = DateTime.UtcNow.AddDays(-9), TotalPrice = 70000, OrderStatus = "Confirmed", PaymentStatus = "Paid", PhoneNumber = "9867843210", StreetAddress = "45 Oak St", City = "City C", State = " Makurdi", PostalCode = "77898", Name = "James Wis" },
                new OrderHeader { Id = orderHeaderIds[3].ToString(), UserId = userIds[3].ToString(), OrderDate = DateTime.UtcNow.AddDays(-6), ShippingDate = DateTime.UtcNow.AddDays(-4), TotalPrice = 60000, OrderStatus = "Delivered", PaymentStatus = "Refunded", PhoneNumber = "9876543210", StreetAddress = "956 Oak St", City = "City D", State = "State A", PostalCode = "78754", Name = "Joan Mark" },
                new OrderHeader { Id = orderHeaderIds[4].ToString(), UserId = userIds[4].ToString(), OrderDate = DateTime.UtcNow.AddDays(-1), ShippingDate = DateTime.UtcNow.AddDays(-8), TotalPrice = 87000, OrderStatus = "Confirmed", PaymentStatus = "Paid", PhoneNumber = "9876887210", StreetAddress = "496 Oak St", City = "City E", State = "State Polaris", PostalCode = "99654", Name = "John Matt" },
                new OrderHeader { Id = orderHeaderIds[5].ToString(), UserId = userIds[5].ToString(), OrderDate = DateTime.UtcNow.AddDays(-12), ShippingDate = DateTime.UtcNow.AddDays(-4), TotalPrice = 76000, OrderStatus = "Pending", PaymentStatus = "Refunded", PhoneNumber = "4878743210", StreetAddress = "76 Oak St", City = "City F", State = "State New", PostalCode = "09908", Name = "Matt Paul" },
                new OrderHeader { Id = orderHeaderIds[6].ToString(), UserId = userIds[6].ToString(), OrderDate = DateTime.UtcNow.AddDays(-8), ShippingDate = DateTime.UtcNow.AddDays(-7), TotalPrice = 30000, OrderStatus = "Cancelled", PaymentStatus = "Paid", PhoneNumber = "9898743210", StreetAddress = "6 Oak St", City = "City G", State = "State Paris", PostalCode = "88978", Name = "Bana Good" },
                new OrderHeader { Id = orderHeaderIds[7].ToString(), UserId = userIds[7].ToString(), OrderDate = DateTime.UtcNow.AddDays(-9), ShippingDate = DateTime.UtcNow.AddDays(-5), TotalPrice = 90000, OrderStatus = "Confirmed", PaymentStatus = "Refunded", PhoneNumber = "9874543210", StreetAddress = "86 Oak St", City = "City H", State = "State", PostalCode = "00986", Name = "Lurge Luck" },
                new OrderHeader { Id = orderHeaderIds[8].ToString(), UserId = userIds[8].ToString(), OrderDate = DateTime.UtcNow.AddDays(-14), ShippingDate = DateTime.UtcNow.AddDays(-14), TotalPrice = 98000, OrderStatus = "Cancelled", PaymentStatus = "UnPaid", PhoneNumber = "9878453210", StreetAddress = "26 Oak St", City = "City I", State = "State Mark", PostalCode = "00987", Name = "Gate Paulo" },
                new OrderHeader { Id = orderHeaderIds[9].ToString(), UserId = userIds[9].ToString(), OrderDate = DateTime.UtcNow.AddDays(-18), ShippingDate = DateTime.UtcNow.AddDays(-23), TotalPrice = 67000, OrderStatus = "Pending", PaymentStatus = "Refunded", PhoneNumber = "6526543210", StreetAddress = "956 Oak St", City = "City J", State = "State Town", PostalCode = "77654", Name = "Ronald Smith" },
                new OrderHeader { Id = orderHeaderIds[10].ToString(), UserId = userIds[10].ToString(), OrderDate = DateTime.UtcNow.AddDays(-7), ShippingDate = DateTime.UtcNow.AddDays(-3), TotalPrice = 450000, OrderStatus = "Shipped", PaymentStatus = "Paid", PhoneNumber = "9876920210", StreetAddress = "16 Oak St", City = "City K", State = "State V", PostalCode = "88765", Name = "Jane Adam" }
            );

                    modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { Id = orderDetailIds[0].ToString(), OrderHeaderId = orderHeaderIds[0].ToString(), ProductId = productIds[0].ToString(), Count = 2, Price = 1999, UserId = userIds[0].ToString() },
                new OrderDetail { Id = orderDetailIds[1].ToString(), OrderHeaderId = orderHeaderIds[1].ToString(), ProductId = productIds[1].ToString(), Count = 1, Price = 2999, UserId = userIds[1].ToString() },
                new OrderDetail { Id = orderDetailIds[2].ToString(), OrderHeaderId = orderHeaderIds[2].ToString(), ProductId = productIds[2].ToString(), Count = 3, Price = 4999, UserId = userIds[2].ToString() },
                new OrderDetail { Id = orderDetailIds[3].ToString(), OrderHeaderId = orderHeaderIds[3].ToString(), ProductId = productIds[3].ToString(), Count = 5, Price = 4500, UserId = userIds[3].ToString() },
                new OrderDetail { Id = orderDetailIds[4].ToString(), OrderHeaderId = orderHeaderIds[4].ToString(), ProductId = productIds[4].ToString(), Count = 6, Price = 55000, UserId = userIds[4].ToString() },
                new OrderDetail { Id = orderDetailIds[5].ToString(), OrderHeaderId = orderHeaderIds[5].ToString(), ProductId = productIds[5].ToString(), Count = 9, Price = 6700, UserId = userIds[5].ToString() },
                new OrderDetail { Id = orderDetailIds[6].ToString(), OrderHeaderId = orderHeaderIds[6].ToString(), ProductId = productIds[6].ToString(), Count = 3, Price = 8900, UserId = userIds[6].ToString() },
                new OrderDetail { Id = orderDetailIds[7].ToString(), OrderHeaderId = orderHeaderIds[7].ToString(), ProductId = productIds[7].ToString(), Count = 5, Price = 45000, UserId = userIds[7].ToString() },
                new OrderDetail { Id = orderDetailIds[8].ToString(), OrderHeaderId = orderHeaderIds[8].ToString(), ProductId = productIds[8].ToString(), Count = 8, Price = 99000, UserId = userIds[8].ToString() },
                new OrderDetail { Id = orderDetailIds[9].ToString(), OrderHeaderId = orderHeaderIds[9].ToString(), ProductId = productIds[9].ToString(), Count = 7, Price = 8900, UserId = userIds[9].ToString() },
                new OrderDetail { Id = orderDetailIds[10].ToString(), OrderHeaderId = orderHeaderIds[10].ToString(), ProductId = productIds[10].ToString(), Count = 6, Price = 235000, UserId = userIds[10].ToString() }
            );

                 modelBuilder.Entity<ShoppingCartItem>().HasData(
              new ShoppingCartItem { Id = shoppingCartItemIds[0].ToString(), Count = 2, ShoppingCartId = cartIds[0].ToString(), ProductId = productIds[0].ToString(),  UserId = userIds[0].ToString() },
              new ShoppingCartItem { Id = shoppingCartItemIds[1].ToString(), Count = 1, ShoppingCartId = cartIds[1].ToString(), ProductId = productIds[1].ToString(),  UserId = userIds[1].ToString()},
              new ShoppingCartItem { Id = shoppingCartItemIds[2].ToString(), Count = 4, ShoppingCartId = cartIds[2].ToString(), ProductId = productIds[2].ToString(),  UserId = userIds[2].ToString()},
              new ShoppingCartItem { Id = shoppingCartItemIds[3].ToString(), Count = 5, ShoppingCartId = cartIds[3].ToString(), ProductId = productIds[3].ToString(),  UserId = userIds[3].ToString()},
              new ShoppingCartItem { Id = shoppingCartItemIds[4].ToString(), Count = 3, ShoppingCartId = cartIds[4].ToString(), ProductId = productIds[4].ToString(),  UserId = userIds[4].ToString()},
              new ShoppingCartItem { Id = shoppingCartItemIds[5].ToString(), Count = 5, ShoppingCartId = cartIds[5].ToString(), ProductId = productIds[5].ToString(),  UserId = userIds[5].ToString()},
              new ShoppingCartItem { Id = shoppingCartItemIds[6].ToString(), Count = 6, ShoppingCartId = cartIds[6].ToString(), ProductId = productIds[6].ToString(),  UserId = userIds[6].ToString()},
              new ShoppingCartItem { Id = shoppingCartItemIds[7].ToString(), Count = 6, ShoppingCartId = cartIds[7].ToString(), ProductId = productIds[7].ToString(),  UserId = userIds[7].ToString()},
              new ShoppingCartItem { Id = shoppingCartItemIds[8].ToString(), Count = 8, ShoppingCartId = cartIds[8].ToString(), ProductId = productIds[8].ToString(),  UserId = userIds[8].ToString()},
              new ShoppingCartItem { Id = shoppingCartItemIds[9].ToString(), Count = 8, ShoppingCartId = cartIds[9].ToString(), ProductId = productIds[9].ToString(),  UserId = userIds[9].ToString()},
              new ShoppingCartItem { Id = shoppingCartItemIds[10].ToString(), Count = 5, ShoppingCartId = cartIds[10].ToString(), ProductId = productIds[10].ToString(),UserId = userIds[10].ToString() }
          );

                modelBuilder.Entity<Review>().HasData(
             new Review { Id = reviewIds[0].ToString(), ProductId = productIds[0].ToString(), CustomerId = userIds[0].ToString(), Rating = 5, Comment = "Excellent product!", CreatedDate = DateTime.UtcNow.AddDays(-10) },
             new Review { Id = reviewIds[1].ToString(), ProductId = productIds[1].ToString(), CustomerId = userIds[1].ToString(), Rating = 4, Comment = "Good value for the price.", CreatedDate = DateTime.UtcNow.AddDays(-8) },
             new Review { Id = reviewIds[2].ToString(), ProductId = productIds[2].ToString(), CustomerId = userIds[2].ToString(), Rating = 3, Comment = "Satisfactory, but could be improved.", CreatedDate = DateTime.UtcNow.AddDays(-5) },
             new Review { Id = reviewIds[3].ToString(), ProductId = productIds[3].ToString(), CustomerId = userIds[3].ToString(), Rating = 1, Comment = "Fairly pleased with the quality.", CreatedDate = DateTime.UtcNow.AddDays(-3) },
             new Review { Id = reviewIds[4].ToString(), ProductId = productIds[4].ToString(), CustomerId = userIds[4].ToString(), Rating = 2, Comment = "Fairly pleased with the quality.", CreatedDate = DateTime.UtcNow.AddDays(-2) },
             new Review { Id = reviewIds[5].ToString(), ProductId = productIds[5].ToString(), CustomerId = userIds[5].ToString(), Rating = 4, Comment = "Pleased with the quality.", CreatedDate = DateTime.UtcNow.AddDays(-5) },
             new Review { Id = reviewIds[6].ToString(), ProductId = productIds[6].ToString(), CustomerId = userIds[6].ToString(), Rating = 4, Comment = "Pleased with the quality.", CreatedDate = DateTime.UtcNow.AddDays(-13) },
             new Review { Id = reviewIds[7].ToString(), ProductId = productIds[7].ToString(), CustomerId = userIds[7].ToString(), Rating = 5, Comment = "Very very pleased with the quality.", CreatedDate = DateTime.UtcNow.AddDays(-12) },
             new Review { Id = reviewIds[8].ToString(), ProductId = productIds[8].ToString(), CustomerId = userIds[8].ToString(), Rating = 5, Comment = "Awesome quality.", CreatedDate = DateTime.UtcNow.AddDays(-4) },
             new Review { Id = reviewIds[9].ToString(), ProductId = productIds[9].ToString(), CustomerId = userIds[9].ToString(), Rating = 2, Comment = "Not really a great quality.", CreatedDate = DateTime.UtcNow.AddDays(-23) },
             new Review { Id = reviewIds[10].ToString(), ProductId = productIds[10].ToString(), CustomerId = userIds[10].ToString(), Rating = 3, Comment = "Partially pleased with the quality.", CreatedDate = DateTime.UtcNow.AddDays(-4) }
         );
                modelBuilder.Entity<Cart>().HasData(
             new Cart { Id = cartIds[0].ToString(), UserId = userIds[0].ToString(), CreatedDate = DateTime.UtcNow.AddDays(-10) },
             new Cart { Id = cartIds[1].ToString(), UserId = userIds[1].ToString(), CreatedDate = DateTime.UtcNow.AddDays(-8) },
             new Cart { Id = cartIds[2].ToString(), UserId = userIds[2].ToString(), CreatedDate = DateTime.UtcNow.AddDays(-5) },
             new Cart { Id = cartIds[3].ToString(), UserId = userIds[3].ToString(), CreatedDate = DateTime.UtcNow.AddDays(-3) },
             new Cart { Id = cartIds[4].ToString(), UserId = userIds[4].ToString(), CreatedDate = DateTime.UtcNow.AddDays(-2) },
             new Cart { Id = cartIds[5].ToString(), UserId = userIds[5].ToString(), CreatedDate = DateTime.UtcNow.AddDays(-5) },
             new Cart { Id = cartIds[6].ToString(), UserId = userIds[6].ToString(), CreatedDate = DateTime.UtcNow.AddDays(-13) },
             new Cart { Id = cartIds[7].ToString(), UserId = userIds[7].ToString(), CreatedDate = DateTime.UtcNow.AddDays(-12) },
             new Cart { Id = cartIds[8].ToString(), UserId = userIds[8].ToString(), CreatedDate = DateTime.UtcNow.AddDays(-4) },
             new Cart { Id = cartIds[9].ToString(), UserId = userIds[9].ToString(), CreatedDate = DateTime.UtcNow.AddDays(-23) },
             new Cart { Id = cartIds[10].ToString(), UserId = userIds[10].ToString(), CreatedDate = DateTime.UtcNow.AddDays(-4) }
         );


        }

    }
}
