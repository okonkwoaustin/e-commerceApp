using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Data;
using e_commerceApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace e_commerceApp.Application.Services.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly EcommDbContext _ecommDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public int ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCartService(EcommDbContext ecommDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _ecommDbContext = ecommDbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _ecommDbContext.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Product).ToList());
        }
        public static ShoppingCartService GetShoppingCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<EcommDbContext>();
            var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            int cartsId = int.Parse(cartId); 
            return new ShoppingCartService(context, httpContextAccessor) { ShoppingCartId = cartsId };

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

        public async void AddItemToCart(Product product)
        {
            var existingProduct = _ecommDbContext.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                throw new Exception("Product does not exist in the database.");
            }

            var userIdString = _httpContextAccessor.HttpContext!.User.FindFirstValue(JwtRegisteredClaimNames.Jti);

            if (int.TryParse(userIdString, out int userId))
            {
                var shoppingCart = _ecommDbContext.Carts.FirstOrDefault(c => c.Id == ShoppingCartId);

                if (shoppingCart == null)
                {
                    shoppingCart = new Cart
                    {
                        Id = ShoppingCartId,
                        CustomerId = userId, 
                        CreatedDate = DateTime.UtcNow,
                    };

                   await _ecommDbContext.Carts.AddAsync(shoppingCart);
                   await _ecommDbContext.SaveChangesAsync(); 
                }
            }
            else
            {
                throw new Exception("Invalid user ID.");
            }

            var shoppingCartItem = _ecommDbContext.ShoppingCartItems.FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = existingProduct, 
                    Amount = 1
                };
               await _ecommDbContext.ShoppingCartItems.AddAsync(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
           await _ecommDbContext.SaveChangesAsync();
        }


        public void RemoveItemFromCart(Product product)
        {
            var shoppingCartItem = _ecommDbContext.ShoppingCartItems.FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _ecommDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _ecommDbContext.SaveChanges();
        }


        public decimal GetShoppingCartTotal() => _ecommDbContext.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Product.Price * n.Amount).Sum();

        public async Task ClearShoppingCartAsync()
        {
            var items = await _ecommDbContext.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _ecommDbContext.ShoppingCartItems.RemoveRange(items);
            await _ecommDbContext.SaveChangesAsync();
        }

        public async Task<bool> IncrementItemCountAsync(int cartId)
        {
            var cart = await _ecommDbContext.CartItems.FirstOrDefaultAsync(u => u.Id == cartId);
            if (cart == null)
            {
                return false; 
            }           
            IncrementCount(cart, 1);
            await _ecommDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DecrementItemCountAsync(int cartId)
        {

            var cart = await _ecommDbContext.CartItems.FirstOrDefaultAsync(u => u.Id == cartId);
            if (cart == null)
            {
                return false;
            }
            if (cart.Quantity <= 1)
            {
                _ecommDbContext.CartItems.Remove(cart);
                var remainingItemsCount = _ecommDbContext.CartItems
                                         .Where(u => u.UserId == cart.UserId) 
                                        .ToList() 
                                        .Count - 1;  
                _httpContextAccessor.HttpContext?.Session.SetInt32(Initials.SessionCart, remainingItemsCount);
            }
            else
            {
                DecrementCount(cart, 1);
            }

            await _ecommDbContext.SaveChangesAsync();
            return true;
        }

        private int DecrementCount(CartItem cartItems, int count)
        {
            cartItems.Quantity -= count;
            return cartItems.Quantity;
        }

        private int IncrementCount(CartItem cartItems, int count)
        {
            cartItems.Quantity += count;
            return cartItems.Quantity;
        }

        private string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
