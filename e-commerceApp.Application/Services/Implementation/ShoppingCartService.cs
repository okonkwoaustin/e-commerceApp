using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared;
using e_commerceApp.Shared.Data;
using e_commerceApp.Shared.Models;
using e_commerceApp.Shared.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace e_commerceApp.Application.Services.Implementation
{
    public class ShoppingCartService //: IShoppingCartService
    {
        private readonly EcommDbContext _ecommDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ShoppingCartService> _logger;
        private readonly UserManager<User> _userManager;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCartService(EcommDbContext ecommDbContext, IHttpContextAccessor httpContextAccessor,
            ILogger<ShoppingCartService> logger, UserManager<User> userManager)
        {
            _ecommDbContext = ecommDbContext;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _userManager = userManager;
            var cartIdString = _httpContextAccessor.HttpContext?.Session.GetString("cartId");
            if (string.IsNullOrEmpty(cartIdString))
            {
                ShoppingCartId = Guid.NewGuid().ToString();
                _httpContextAccessor.HttpContext!.Session.SetString("cartId", ShoppingCartId.ToString());
            }
            else
            {
                ShoppingCartId = Guid.Parse(cartIdString).ToString();
            }
        }

        public async Task<ServiceResponse<List<ShoppingCartItem>>> GetShoppingCartItems()
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(JwtRegisteredClaimNames.Jti);
                if (string.IsNullOrEmpty(userId))
                {
                    return new ServiceResponse<List<ShoppingCartItem>>(null, false, "User must be logged in to view the shopping cart.");
                }

                var shoppingCart = await _ecommDbContext.Carts
                    .FirstOrDefaultAsync(c => c.UserId == userId && c.ExpirationDate > DateTime.UtcNow);

                if (shoppingCart == null)
                {
                    return new ServiceResponse<List<ShoppingCartItem>>(new List<ShoppingCartItem>(), true, "No active cart found.");
                }
                var cartItems = await _ecommDbContext.ShoppingCartItems
                    .Where(n => n.ShoppingCartId == shoppingCart.Id)
                    .Include(n => n.Product)
                    .ToListAsync();

                return new ServiceResponse<List<ShoppingCartItem>>(cartItems, true, "Shopping cart items retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<ShoppingCartItem>>(null, false, $"An error occurred: {ex.Message}");
            }
        }

        /* public void AddItemToCart(Product product)
         {
             var shoppingCartItem = _ecommDbContext.ShoppingCartItems.FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == ShoppingCartId);

             if (shoppingCartItem == null)
             {
                 shoppingCartItem = new ShoppingCartItem()
                 {
                     ShoppingCartId = ShoppingCartId,
                     Product = product,
                     Amount = 1
                 };

                 _ecommDbContext.ShoppingCartItems.Add(shoppingCartItem);
             }
             else
             {
                 shoppingCartItem.Amount++;
             }
             _ecommDbContext.SaveChanges();
         }*/

        /*
         public async Task AddItemToCart(Product product)
         {
             var executionStrategy = _ecommDbContext.Database.CreateExecutionStrategy();

             await executionStrategy.ExecuteAsync(async () =>
             {
                 using (var transaction = await _ecommDbContext.Database.BeginTransactionAsync())
                 {
                     try
                     {
                         var existingProduct = await _ecommDbContext.Products
                             .FirstOrDefaultAsync(p => p.Id == product.Id);

                         if (existingProduct == null)
                         {
                             throw new Exception("Product does not exist in the database.");
                         }

                         var userIdString = _httpContextAccessor.HttpContext?.User.FindFirstValue(JwtRegisteredClaimNames.Jti);

                         var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(JwtRegisteredClaimNames.Jti);
                         string email = userId ?? _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email)!; 

                         string cartId = _httpContextAccessor.HttpContext?.Session.GetString("cartId")!;

                         // Find an existing cart for the logged-in user or guest
                        Cart shoppingCart = null;

                         if (!string.IsNullOrEmpty(email))
                         {
                             // If the user is logged in, use their UserId
                             shoppingCart = await _ecommDbContext.Carts.FirstOrDefaultAsync(c => c.Email == email && c.ExpirationDate > DateTime.UtcNow);
                         }

                         if (shoppingCart == null && !string.IsNullOrEmpty(cartId))
                         {
                             // If the user is not logged in, use the session-based cartId
                             shoppingCart = await _ecommDbContext.Carts
                                 .FirstOrDefaultAsync(c => c.Id.ToString() == cartId && c.ExpirationDate > DateTime.UtcNow); // Only active carts
                         }


                         //var shoppingCart = await _ecommDbContext.Carts.FirstOrDefaultAsync(c => c.Id == ShoppingCartId && c.ExpirationDate > DateTime.UtcNow); 

                         if (shoppingCart == null)
                         {
                             shoppingCart = new Cart
                             {
                                 Id = ShoppingCartId,
                                 Email = email ?? userId,  
                                 CreatedDate = DateTime.UtcNow,
                                 ExpirationDate = DateTime.UtcNow.AddDays(3) 
                             };

                             await _ecommDbContext.Carts.AddAsync(shoppingCart);
                             await _ecommDbContext.SaveChangesAsync();
                             if (string.IsNullOrEmpty(userId))
                             {
                                 _httpContextAccessor.HttpContext?.Session.SetString("cartId", shoppingCart.Id.ToString());
                             }
                         }
                         var shoppingCartItem = await _ecommDbContext.ShoppingCartItems
                             .FirstOrDefaultAsync(n => n.ProductId == product.Id && n.ShoppingCartId == shoppingCart.Id);

                         if (shoppingCartItem == null)
                         {
                             shoppingCartItem = new ShoppingCartItem
                             {
                                 ShoppingCartId = shoppingCart.Id,
                                 ProductId = product.Id,
                                 Count = 1
                             };
                             await _ecommDbContext.ShoppingCartItems.AddAsync(shoppingCartItem);
                         }
                         else
                         {
                             shoppingCartItem.Count++;
                         }

                         await _ecommDbContext.SaveChangesAsync();
                         await transaction.CommitAsync();
                     }
                     catch (Exception ex)
                     {
                         await transaction.RollbackAsync();
                         throw new Exception("An error occurred while adding the item to the cart.", ex);
                     }
                 }
             });
         }
 */

        public async Task AddItemToCart(Product product)
        {
            var executionStrategy = _ecommDbContext.Database.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _ecommDbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var existingProduct = await _ecommDbContext.Products
                            .FirstOrDefaultAsync(p => p.Id == product.Id);

                        if (existingProduct == null)
                        {
                            throw new Exception("Product does not exist in the database.");
                        }
                        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue("UserId");
                        if (string.IsNullOrEmpty(userId))
                        {
                            throw new Exception("User must be logged in to add items to the cart.");
                        }
                        var shoppingCart = await _ecommDbContext.Carts
                            .FirstOrDefaultAsync(c => c.UserId == userId && c.ExpirationDate > DateTime.UtcNow);

                        if (shoppingCart == null)
                        {
                            shoppingCart = new Cart
                            {
                                Id = Guid.NewGuid().ToString(),
                                UserId = userId,
                                CreatedDate = DateTime.UtcNow,
                                ExpirationDate = DateTime.UtcNow.AddDays(3)
                            };

                            await _ecommDbContext.Carts.AddAsync(shoppingCart);
                            await _ecommDbContext.SaveChangesAsync();
                        }
                        var shoppingCartItem = await _ecommDbContext.ShoppingCartItems
                            .FirstOrDefaultAsync(n => n.ProductId == product.Id && n.ShoppingCartId == shoppingCart.Id);

                        if (shoppingCartItem == null)
                        {
                            shoppingCartItem = new ShoppingCartItem
                            {
                                ShoppingCartId = shoppingCart.Id,
                                ProductId = product.Id,
                                Count = 1,
                                UserId = userId,
                            };
                            await _ecommDbContext.ShoppingCartItems.AddAsync(shoppingCartItem);
                        }
                        else
                        {
                            shoppingCartItem.Count++;
                        }

                        await _ecommDbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw new Exception("An error occurred while adding the item to the cart: " + ex.Message);
                    }
                }
            });
        }




        public async Task<ServiceResponse<bool>> RemoveItemFromCart(Product product)
        {
            try
            { 
                var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue("UserId");

                if (string.IsNullOrEmpty(userId))
                {
                    return new ServiceResponse<bool>(false, false, "User ID not found.");
                }
                var shoppingCart = await _ecommDbContext.Carts
                    .FirstOrDefaultAsync(c => c.UserId == userId && c.ExpirationDate > DateTime.UtcNow);

                if (shoppingCart == null)
                {
                    _logger.LogError($"Shopping cart not found for UserId {userId} or cart expired.");
                    return new ServiceResponse<bool>(false, false, "Shopping cart not found.");
                }
                if (product == null || string.IsNullOrEmpty(product.Id))
                {
                    return new ServiceResponse<bool>(false, false, "Invalid product.");
                }
                var shoppingCartItem = await _ecommDbContext.ShoppingCartItems
                    .FirstOrDefaultAsync(n => n.ProductId == product.Id && n.ShoppingCartId == shoppingCart.Id);

                if (shoppingCartItem == null)
                {
                    return new ServiceResponse<bool>(false, false, "Item not found in cart.");
                }
                if (shoppingCartItem.Count > 1)
                {
                    shoppingCartItem.Count--;
                    await _ecommDbContext.SaveChangesAsync();
                    return new ServiceResponse<bool>(true, true, "Item quantity reduced in cart.");
                }
                else
                {
                    _ecommDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                    await _ecommDbContext.SaveChangesAsync();
                    return new ServiceResponse<bool>(true, true, "Item removed from cart successfully.");
                }
               
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>(false, false, $"An error occurred: {ex.Message}");
            }
        }




        public decimal GetShoppingCartTotal()
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue("UserId");
            return _ecommDbContext.ShoppingCartItems.Where(n => n.UserId == userId).Select(n => n.Product.Price * n.Count).Sum();

        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await _ecommDbContext.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _ecommDbContext.ShoppingCartItems.RemoveRange(items);
            await _ecommDbContext.SaveChangesAsync();
        }

        public async Task<ServiceResponse<bool>> IncrementItemCountAsync(string productId)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext!.User.FindFirstValue("UserId");

                var cart = await _ecommDbContext.ShoppingCartItems
                    .FirstOrDefaultAsync(u => u.ProductId == productId && u.UserId == userId);
                if (cart == null)
                {
                    return new ServiceResponse<bool>(false, false, "Item not found in the cart.");
                }
                cart.Count++;
                await _ecommDbContext.SaveChangesAsync();
                return new ServiceResponse<bool>(true, true, "Item count incremented successfully.");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>(false, false, $"An error occurred while incrementing the item count: {ex.Message}");
            }
        }


        public async Task<ServiceResponse<bool>> DecrementItemCountAsync(string productId)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext!.User.FindFirstValue("UserId");

                var cart = await _ecommDbContext.ShoppingCartItems
                    .FirstOrDefaultAsync(u => u.ProductId == productId && u.UserId == userId);
                if (cart == null)
                {
                    return new ServiceResponse<bool>(false, false, "Item not found in the cart.");
                }

                if (cart.Count <= 1)
                {
                    _ecommDbContext.ShoppingCartItems.Remove(cart);
                }
                else
                {
                    cart.Count--;
                }
                await _ecommDbContext.SaveChangesAsync();
                return new ServiceResponse<bool>(true, true, "Item count decremented successfully.");
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>(false, false, $"An error occurred while decrementing the item count: {ex.Message}");
            }
        }


        //public async Task<Guid> CreateOrderFromCartAsync(Guid userId)
        //{
        //    var cart = await _ecommDbContext.Carts
        //        .Include(c => c.ShoppingCartItems)
        //        .ThenInclude(si => si.Product)
        //        .FirstOrDefaultAsync(c => c.UserId == userId && c.ExpirationDate > DateTime.Now);

        //    var claims = _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.Email);

        //    if (cart == null || !cart.ShoppingCartItems.Any())
        //    {
        //        throw new Exception("No items in the cart to create an order.");
        //    }
        //    var user = await _userManager.FindByEmailAsync(userId);
        //    // Create the order header
        //    var orderHeader = new OrderHeader
        //    {
        //        Id = Guid.NewGuid(),
        //        UserId = userId,
        //        OrderDate = DateTime.Now,
        //        ShippingDate = DateTime.Now.AddHours(5),
        //        OrderStatus = Initials.StatusPending,
        //        PaymentStatus = Initials.PaymentStatusPending,
        //        PhoneNumber = "123-456-7890", // This should come from user input
        //        StreetAddress = "123 Main St", // This should come from user input
        //        City = "Some City", // This should come from user input
        //        State = "Some State", // This should come from user input
        //        PostalCode = "12345", // This should come from user input
        //        Name = "John Doe", // This should come from user input
        //        UnitPrice = 0, // Will calculate in the order details
        //        TotalPrice = 0, // Will calculate in the order details
        //        OrderDetails = new List<OrderDetail>()
        //    };

        //    foreach (var item in cart.ShoppingCartItems)
        //    {
        //        var orderDetail = new OrderDetail
        //        {
        //            Id = Guid.NewGuid(),
        //            OrderHeaderId = orderHeader.Id,
        //            ProductId = item.ProductId,
        //            Product = item.Product,
        //            Count = item.Count,
        //            Price = item.Product.Price,
        //            UserId = userId
        //        };
        //        orderHeader.OrderDetails.Add(orderDetail);
        //    }

        //    orderHeader.TotalPrice = orderHeader.OrderDetails.Sum(od => od.Price * od.Count);
        //    orderHeader.UnitPrice = orderHeader.TotalPrice / orderHeader.OrderDetails.Count;

        //    _ecommDbContext.OrderHeaders.Add(orderHeader);
        //    await _ecommDbContext.SaveChangesAsync();

        //    _ecommDbContext.ShoppingCartItems.RemoveRange(cart.ShoppingCartItems);
        //    await _ecommDbContext.SaveChangesAsync();

        //    return orderHeader.Id;
        //}



    }
}
