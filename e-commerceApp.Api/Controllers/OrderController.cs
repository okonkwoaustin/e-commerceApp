using e_commerceApp.Application.Dto;
using e_commerceApp.Application.Services.Implementation;
using e_commerceApp.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe.Climate;
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
            int usersId = int.Parse(userId);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            await _ordersService.StoreOrderAsync(items, usersId, userEmailAddress);
            await _shoppingCartService.ClearShoppingCartAsync();

            return Ok(new { Message = "Order completed successfully." });
        }
        [HttpGet("order")]
        public async Task<IActionResult> GetOrderByUserIdAndRole()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            int usersId = int.Parse(userId);
            var orders = await _ordersService.GetOrderByUserIdAndRoleAsync(usersId, userRole);
            return Ok(orders);
        }

        [HttpPost("details-pay-now")]
        public async Task<IActionResult> Details_PAY_NOW([FromBody] PaymentRequest request)
        {
            if (request == null || request.OrderId <= 0)
            {
                return BadRequest("Invalid order ID.");
            }

            // Call the payment service to create the payment session
            var sessionUrl = await _ordersService.CreateStripeCheckoutSessionAsync(request.OrderId);

            if (string.IsNullOrEmpty(sessionUrl))
            {
                return StatusCode(500, "Failed to create payment session.");
            }
            return Ok(new { SessionUrl = sessionUrl });
        }

        // Optional: Handle payment confirmation or cancel (if needed)
        [HttpGet("payment-confirmation")]
        public IActionResult PaymentConfirmation([FromQuery] int orderHeaderId)
        {
            var confirmPayment =  _ordersService.PaymentConfirmation(orderHeaderId);
            return Ok(new { Message = "Payment successful", ConfirmPayment = confirmPayment });
        }

        [HttpPost("cancel-order")]
        public async Task<IActionResult> CancelOrder([FromBody] int orderId)
        {
            var result = await _ordersService.CancelOrderAsync(orderId);
            if (!result)
            {
                return StatusCode(500, "Order cancellation failed.");
            }
            return Ok(new { Message = "Order cancelled successfully." });
        }

        [HttpPost("plus/{cartId}")]
        public async Task<IActionResult> Plus(int cartId)
        {
            var result = await _shoppingCartService.IncrementItemCountAsync(cartId);
            if (!result)
            {
                return NotFound("Cart item not found.");
            }
            return Ok(new { Message = "Item count incremented successfully." });
        }

        [HttpPost("minus/{cartId}")]
        public async Task<IActionResult> Minus(int cartId)
        {      
            var result = await _shoppingCartService.DecrementItemCountAsync(cartId);
            if (!result)
            {
                return NotFound("Cart item not found.");
            }
            return Ok(new { Message = "Item count decremented successfully." });
        }
    }
}
