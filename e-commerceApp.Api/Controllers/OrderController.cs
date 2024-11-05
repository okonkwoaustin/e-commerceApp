using e_commerceApp.Application.Dto;
using e_commerceApp.Application.Services.Implementation;
using e_commerceApp.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace e_commerceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderService _ordersService;

        public OrderController(IProductService productService, IShoppingCartService shoppingCartService, IOrderService orderService)
        {
            _productService = productService;
            _shoppingCartService = shoppingCartService;
            _ordersService = orderService;
        }
        [HttpGet("shopping-cart")]
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCartService.GetShoppingCartItems();
            _shoppingCartService.ShoppingCartItems = items;

            var response = new ShoppingCartRequest()
            {
                ShoppingCartService = _shoppingCartService,
                ShoppingCartTotal = _shoppingCartService.GetShoppingCartTotal()
            };
            return Ok(response);
        }
        [HttpPost("add-to-cart/{id}")]
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _productService.GetProductByIdAsync(id);
            if (item == null)
            {
                return NotFound(new { Message = "Product not found." });
            }
            _shoppingCartService.AddItemToCart(item);
            return Ok(new { Message = "Item added to cart successfully." });
        }
        [HttpDelete("remove-from-cart/{id}")]
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _productService.GetProductByIdAsync(id);
            if (item == null)
            {
                return NotFound(new { Message = "Product not found." });
            }
            _shoppingCartService.RemoveItemFromCart(item);
            return Ok(new { Message = "Item removed from cart successfully." });
        }

        [HttpPost("complete-order")]
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCartService.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCartService.ClearShoppingCartAsync();

            return Ok(new { Message = "Order completed successfully." });
        }
        [HttpGet("order")]
        public async Task<IActionResult> GetOrderByUserIdAndRole()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrderByUserIdAndRoleAsync(userId, userRole);
            return Ok(orders);
        }
    }
}
