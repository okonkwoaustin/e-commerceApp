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
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", UserName = "john.doe@example.com", PhoneNumber = "123456-7890", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", UserName = "jane.smith@example.com", PhoneNumber = "9876543210", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 3, FirstName = "Ike", LastName = "Sunny", Email = "ike.sunny@example.com", UserName = "ike.sunny@example.com", PhoneNumber = "4567891234", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 4, FirstName = "Adam", LastName = "Jane", Email = "adam.jane@example.com", UserName = "adam.jane@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 5, FirstName = "Ronald", LastName = "Smith", Email = "ronald.smith@example.com", UserName = "ronald.smith@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 6, FirstName = "Gate", LastName = "Paulo", Email = "gate.paulo@example.com", UserName = "gate.paulo@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 7, FirstName = "Lurge", LastName = "Luck", Email = "lurge.luck@example.com", UserName = "lurge.luck@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 8, FirstName = "Bana", LastName = "Good", Email = "bana.good@example.com", UserName = "bana.good@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 9, FirstName = "Matt", LastName = "Paul", Email = "matt.paul@example.com", UserName = "matt.paul@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 10, FirstName = "John", LastName = "Matt", Email = "john.matt@example.com", UserName = "john.matt@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new User { Id = 11, FirstName = "Joan", LastName = "Mark", Email = "joan.mark@example.com", UserName = "joan.mark@example.com", PhoneNumber = "3216549870", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

                    modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Phone" },
                    new Category { Id = 2, Name = "Laptop" },
                    new Category { Id = 3, Name = "Charger" },
                    new Category { Id = 4, Name = "Earpiece" },
                    new Category { Id = 5, Name = "Tablet" },  
                    new Category { Id = 6, Name = "Headphones" },  
                    new Category { Id = 7, Name = "Smartwatch" },  
                    new Category { Id = 8, Name = "Accessories" },  
                    new Category { Id = 9, Name = "Gaming" },  
                    new Category { Id = 10, Name = "Fashion" },  
                    new Category { Id = 11, Name = "Home Appliances" }  
                );
         

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Product 1", Description = "Description of Product 1", Price = 170000, StockQuantity = 100, CartegoryId = 1, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.Availble, ImageUrl = "https://example.com/images/product1.jpg" },
                new Product { Id = 2, Title = "Product 2", Description = "Description of Product 2", Price = 295000, StockQuantity = 50, CartegoryId = 2, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.Availble, ImageUrl = "https://example.com/images/product2.jpg" },
                new Product { Id = 3, Title = "Product 3", Description = "Description of Product 3", Price = 49500, StockQuantity = 40, CartegoryId = 3, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.Discontinued, ImageUrl = "https://example.com/images/product3.jpg" },
                new Product { Id = 4, Title = "Product 4", Description = "Description of Product 4", Price = 50000, StockQuantity = 500, CartegoryId = 4, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product4.jpg" },
                new Product { Id = 5, Title = "Product 5", Description = "Description of Product 5", Price = 900000, StockQuantity = 700, CartegoryId = 5, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product5.jpg" },
                new Product { Id = 6, Title = "Product 6", Description = "Description of Product 6", Price = 856000, StockQuantity = 900, CartegoryId = 6, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product6.jpg" },
                new Product { Id = 7, Title = "Product 7", Description = "Description of Product 7", Price = 7000m, StockQuantity = 80, CartegoryId = 7, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product7.jpg" },
                new Product { Id = 8, Title = "Product 8", Description = "Description of Product 8", Price = 25000, StockQuantity = 800, CartegoryId = 8, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product8.jpg" },
                new Product { Id = 9, Title = "Product 9", Description = "Description of Product 9", Price = 780000, StockQuantity = 700, CartegoryId = 9, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product9.jpg" },
                new Product { Id = 10, Title = "Product 10", Description = "Description of Product 10", Price = 56000, StockQuantity = 700, CartegoryId = 10, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product10.jpg" },
                new Product { Id = 11, Title = "Product 11", Description = "Description of Product 11", Price = 45000, StockQuantity = 600, CartegoryId = 11, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow, ProductStatus = ProductStatus.OutofStock, ImageUrl = "https://example.com/images/product11.jpg" }
            );

            modelBuilder.Entity<OrderHeader>().HasData(
                new OrderHeader { Id = 1, UserId = 1, OrderDate = DateTime.UtcNow.AddDays(-10), ShippingDate = DateTime.UtcNow.AddDays(-5), TotalPrice = 9999, OrderStatus = "Shipped", PaymentStatus = "Paid", PhoneNumber = "1234567890", StreetAddress = "123 Main St", City = "City A", State = "Agege", PostalCode = "12345", Name = "John Doe" },
                new OrderHeader { Id = 2, UserId = 2, OrderDate = DateTime.UtcNow.AddDays(-8), ShippingDate = DateTime.UtcNow.AddDays(-4), TotalPrice = 19999, OrderStatus = "Delivered", PaymentStatus = "UnPaid", PhoneNumber = "98789943210", StreetAddress = "86 Oak St", City = "City B", State = "Ajah", PostalCode = "67890", Name = "Jane Sunny" },
                new OrderHeader { Id = 3, UserId = 3, OrderDate = DateTime.UtcNow.AddDays(-9), ShippingDate = DateTime.UtcNow.AddDays(-9), TotalPrice = 70000, OrderStatus = "Confirmed", PaymentStatus = "Paid", PhoneNumber = "9867843210", StreetAddress = "45 Oak St", City = "City C", State = " Makurdi", PostalCode = "77898", Name = "James Wis" },
                new OrderHeader { Id = 4, UserId = 4, OrderDate = DateTime.UtcNow.AddDays(-6), ShippingDate = DateTime.UtcNow.AddDays(-4), TotalPrice = 60000, OrderStatus = "Delivered", PaymentStatus = "Refunded", PhoneNumber = "9876543210", StreetAddress = "956 Oak St", City = "City D", State = "State A", PostalCode = "78754", Name = "Joan Mark" },
                new OrderHeader { Id = 5, UserId = 5, OrderDate = DateTime.UtcNow.AddDays(-1), ShippingDate = DateTime.UtcNow.AddDays(-8), TotalPrice = 87000, OrderStatus = "Confirmed", PaymentStatus = "Paid", PhoneNumber = "9876887210", StreetAddress = "496 Oak St", City = "City E", State = "State Polaris", PostalCode = "99654", Name = "John Matt" },
                new OrderHeader { Id = 6, UserId = 6, OrderDate = DateTime.UtcNow.AddDays(-12), ShippingDate = DateTime.UtcNow.AddDays(-4), TotalPrice = 76000, OrderStatus = "Pending", PaymentStatus = "Refunded", PhoneNumber = "4878743210", StreetAddress = "76 Oak St", City = "City F", State = "State New", PostalCode = "09908", Name = "Matt Paul" },
                new OrderHeader { Id = 7, UserId = 7, OrderDate = DateTime.UtcNow.AddDays(-8), ShippingDate = DateTime.UtcNow.AddDays(-7), TotalPrice = 30000, OrderStatus = "Cancelled", PaymentStatus = "Paid", PhoneNumber = "9898743210", StreetAddress = "6 Oak St", City = "City G", State = "State Paris", PostalCode = "88978", Name = "Bana Good" },
                new OrderHeader { Id = 8, UserId = 8, OrderDate = DateTime.UtcNow.AddDays(-9), ShippingDate = DateTime.UtcNow.AddDays(-5), TotalPrice = 90000, OrderStatus = "Confirmed", PaymentStatus = "Refunded", PhoneNumber = "9874543210", StreetAddress = "86 Oak St", City = "City H", State = "State", PostalCode = "00986", Name = "Lurge Luck" },
                new OrderHeader { Id = 9, UserId = 9, OrderDate = DateTime.UtcNow.AddDays(-14), ShippingDate = DateTime.UtcNow.AddDays(-14), TotalPrice = 98000, OrderStatus = "Cancelled", PaymentStatus = "UnPaid", PhoneNumber = "9878453210", StreetAddress = "26 Oak St", City = "City I", State = "State Mark", PostalCode = "00987", Name = "Gate Paulo" },
                new OrderHeader { Id = 10, UserId = 10, OrderDate = DateTime.UtcNow.AddDays(-18), ShippingDate = DateTime.UtcNow.AddDays(-23), TotalPrice = 67000, OrderStatus = "Pending", PaymentStatus = "Refunded", PhoneNumber = "6526543210", StreetAddress = "956 Oak St", City = "City J", State = "State Town", PostalCode = "77654", Name = "Ronald Smith" },
                new OrderHeader { Id = 11, UserId = 11, OrderDate = DateTime.UtcNow.AddDays(-7), ShippingDate = DateTime.UtcNow.AddDays(-3), TotalPrice = 450000, OrderStatus = "Shipped", PaymentStatus = "Paid", PhoneNumber = "9876920210", StreetAddress = "16 Oak St", City = "City K", State = "State V", PostalCode = "88765", Name = "Jane Adam" }
            );

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { Id = 1, OrderHeaderId = 1, ProductId = 1, Count = 2, Price = 1999, UserId = 1 },
                new OrderDetail { Id = 2, OrderHeaderId = 2, ProductId = 2, Count = 1, Price = 2999, UserId = 2 },
                new OrderDetail { Id = 3, OrderHeaderId = 3, ProductId = 3, Count = 3, Price = 4999, UserId = 3 },
                new OrderDetail { Id = 4, OrderHeaderId = 4, ProductId = 4, Count = 5, Price = 4500, UserId = 4 },
                new OrderDetail { Id = 5, OrderHeaderId = 5, ProductId = 5, Count = 6, Price = 55000, UserId = 5 },
                new OrderDetail { Id = 6, OrderHeaderId = 6, ProductId = 6, Count = 9, Price = 6700, UserId = 6 },
                new OrderDetail { Id = 7, OrderHeaderId = 7, ProductId = 7, Count = 3, Price = 8900, UserId = 7 },
                new OrderDetail { Id = 8, OrderHeaderId = 8, ProductId = 8, Count = 5, Price = 45000, UserId = 8 },
                new OrderDetail { Id = 9, OrderHeaderId = 9, ProductId = 9, Count = 8, Price = 99000, UserId = 9 },
                new OrderDetail { Id = 10, OrderHeaderId = 10, ProductId = 10, Count = 7, Price = 8900, UserId = 10 },
                new OrderDetail { Id = 11, OrderHeaderId = 11, ProductId = 11, Count = 6, Price = 235000, UserId = 11 }
            );

            modelBuilder.Entity<ShoppingCartItem>().HasData(
                new ShoppingCartItem { Id = 1, Amount = 2, ShoppingCartId = 1, ProductId = 1 },
                new ShoppingCartItem { Id = 2, Amount = 1, ShoppingCartId = 2, ProductId = 2 },
                new ShoppingCartItem { Id = 3, Amount = 4, ShoppingCartId = 3, ProductId = 3 },
                new ShoppingCartItem { Id = 4, Amount = 5, ShoppingCartId = 4, ProductId = 4 },
                new ShoppingCartItem { Id = 5, Amount = 3, ShoppingCartId = 5, ProductId = 5 },
                new ShoppingCartItem { Id = 6, Amount = 5, ShoppingCartId = 6, ProductId = 6 },
                new ShoppingCartItem { Id = 7, Amount = 6, ShoppingCartId = 7, ProductId = 7 },
                new ShoppingCartItem { Id = 8, Amount = 6, ShoppingCartId = 8, ProductId = 8 },
                new ShoppingCartItem { Id = 9, Amount = 8, ShoppingCartId = 9, ProductId = 9 },
                new ShoppingCartItem { Id = 10, Amount = 8, ShoppingCartId = 10, ProductId = 10 },
                new ShoppingCartItem { Id = 11, Amount = 5, ShoppingCartId = 11, ProductId = 11 }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, ProductId = 1, CustomerId = 1, Rating = 5, Comment = "Excellent product!", CreatedDate = DateTime.UtcNow.AddDays(-10) },
                new Review { Id = 2, ProductId = 2, CustomerId = 2, Rating = 4, Comment = "Good value for the price.", CreatedDate = DateTime.UtcNow.AddDays(-8) },
                new Review { Id = 3, ProductId = 3, CustomerId = 3, Rating = 3, Comment = "Satisfactory, but could be improved.", CreatedDate = DateTime.UtcNow.AddDays(-5) },
                new Review { Id = 4, ProductId = 4, CustomerId = 4, Rating = 1, Comment = "Fairly pleased with the quality.", CreatedDate = DateTime.UtcNow.AddDays(-3) },
                new Review { Id = 5, ProductId = 5, CustomerId = 5, Rating = 2, Comment = "Fairly pleased with the quality.", CreatedDate = DateTime.UtcNow.AddDays(-2) },
                new Review { Id = 6, ProductId = 6, CustomerId = 6, Rating = 4, Comment = "pleased with the quality.", CreatedDate = DateTime.UtcNow.AddDays(-5) },
                new Review { Id = 7, ProductId = 7, CustomerId = 7, Rating = 4, Comment = "pleased with the quality.", CreatedDate = DateTime.UtcNow.AddDays(-13) },
                new Review { Id = 8, ProductId = 8, CustomerId = 8, Rating = 5, Comment = "Very very pleased with the quality.", CreatedDate = DateTime.UtcNow.AddDays(-12) },
                new Review { Id = 9, ProductId = 9, CustomerId = 9, Rating = 5, Comment = "Awesome  quality.", CreatedDate = DateTime.UtcNow.AddDays(-4) },
                new Review { Id = 10, ProductId = 10, CustomerId = 10, Rating = 2, Comment = "Not really a great quality.", CreatedDate = DateTime.UtcNow.AddDays(-23) },
                new Review { Id = 11, ProductId = 11, CustomerId = 11, Rating = 3, Comment = "Patially pleased with the quality.", CreatedDate = DateTime.UtcNow.AddDays(-4) }
            );
            modelBuilder.Entity<Cart>().HasData(
                new Cart { Id = 1, CustomerId = 1, CreatedDate = DateTime.UtcNow.AddDays(-10) },
                new Cart { Id = 2, CustomerId = 2, CreatedDate = DateTime.UtcNow.AddDays(-8) },
                new Cart { Id = 3, CustomerId = 3, CreatedDate = DateTime.UtcNow.AddDays(-5) },
                new Cart { Id = 4, CustomerId = 4, CreatedDate = DateTime.UtcNow.AddDays(-3) },
                new Cart { Id = 5, CustomerId = 5, CreatedDate = DateTime.UtcNow.AddDays(-2) },
                new Cart { Id = 6, CustomerId = 6, CreatedDate = DateTime.UtcNow.AddDays(-5) },
                new Cart { Id = 7, CustomerId = 7, CreatedDate = DateTime.UtcNow.AddDays(-13) },
                new Cart { Id = 8, CustomerId = 8, CreatedDate = DateTime.UtcNow.AddDays(-12) },
                new Cart { Id = 9, CustomerId = 9, CreatedDate = DateTime.UtcNow.AddDays(-4) },
                new Cart { Id = 10, CustomerId = 10, CreatedDate = DateTime.UtcNow.AddDays(-23) },
                new Cart { Id = 11, CustomerId = 11, CreatedDate = DateTime.UtcNow.AddDays(-4) }
            );


        }

    }
}
