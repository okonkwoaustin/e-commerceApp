using e_commerceApp.Application.Dto;
using e_commerceApp.Application.Services.Implementation;
using e_commerceApp.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace e_commerceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ShoppingCartService _shoppingCartService;
        private readonly IOrderService _ordersService;

        public OrderController(IProductService productService, ShoppingCartService shoppingCartService, IOrderService orderService)
        {
            _productService = productService;
            _shoppingCartService = shoppingCartService;
            _ordersService = orderService;
        }


        [HttpGet("shopping-cart")]
        public async Task<IActionResult> ShoppingCart()
        {
            var items = await _shoppingCartService.GetShoppingCartItems();
            _shoppingCartService.ShoppingCartItems = items.Data;
            var response = new ShoppingCartRequest()
            {
                ShoppingCartService = _shoppingCartService,
                ShoppingCartTotal = _shoppingCartService.GetShoppingCartTotal()
            };

            return Ok(response);
        }



        [HttpPost("add-to-cart/{id}")]
        public async Task<IActionResult> AddItemToShoppingCart(string id)
        {
            var item = await _productService.GetProductByIdAsync(id);
            if (item == null)
            {
                return NotFound(new { Message = "Product not found." });
            }
            await _shoppingCartService.AddItemToCart(item.Data);
            return Ok(new { Message = "Item added to cart successfully." });
        }
        [HttpDelete("remove-from-cart/{id}")]
        public async Task<IActionResult> RemoveItemFromShoppingCart(string id)
        {
            var item = await _productService.GetProductByIdAsync(id);
            if (item.Data == null)
            {
                return NotFound(new { Message = "Product not found." });
            }
            var result = await _shoppingCartService.RemoveItemFromCart(item.Data);
            return Ok(result);
        }

        [HttpPost("complete-order")]
        public async Task<IActionResult> CompleteOrder()
        {
            var items = await _shoppingCartService.GetShoppingCartItems();
            string userId = User.FindFirstValue(JwtRegisteredClaimNames.Jti);

            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            await _ordersService.StoreOrderAsync(items.Data, userId, userEmailAddress);
            await _shoppingCartService.ClearShoppingCartAsync();
            return Ok(new { Message = "Order completed successfully." });
        }
        [HttpGet("order")]
        public async Task<IActionResult> GetOrderByUserIdAndRole()
        {
            string userId = User.FindFirstValue(JwtRegisteredClaimNames.Jti);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _ordersService.GetOrderByUserIdAndRoleAsync(userId, userRole);
            return Ok(orders);
        }

        [HttpPost("details-pay-now")]
        public async Task<IActionResult> Details_PAY_NOW([FromBody] PaymentRequest request)
        {
            var sessionUrl = await _ordersService.CreateStripeCheckoutSessionAsync(request.OrderId);

            if (string.IsNullOrEmpty(sessionUrl))
            {
                return StatusCode(500, "Failed to create payment session.");
            }
            return Ok(new { SessionUrl = sessionUrl });
        }

        [HttpGet("payment-confirmation")]
        public IActionResult PaymentConfirmation([FromQuery] string orderHeaderId)
        {
            var confirmPayment = _ordersService.PaymentConfirmation(orderHeaderId);
            return Ok(new { Message = "Payment successful", ConfirmPayment = confirmPayment });
        }

        [HttpPost("cancel-order")]
        public async Task<IActionResult> CancelOrder([FromBody] string orderId)
        {
            var result = await _ordersService.CancelOrderAsync(orderId);
            if (!result)
            {
                return StatusCode(500, "Order cancellation failed.");
            }
            return Ok(new { Message = "Order cancelled successfully." });
        }

        [HttpPost("plus/{cartId}")]
        public async Task<IActionResult> Plus(string cartId)
        {
            var result = await _shoppingCartService.IncrementItemCountAsync(cartId);
            if (!result.success)
            {
                return NotFound("Cart item not found.");
            }
            return Ok(new { Message = "Item count incremented successfully." });
        }

        [HttpPost("minus/{cartId}")]
        public async Task<IActionResult> Minus(string cartId)
        {
            var result = await _shoppingCartService.DecrementItemCountAsync(cartId);
            if (!result.success)
            {
                return NotFound("Cart item not found.");
            }
            return Ok(new { Message = "Item count decremented successfully." });
        }
    }
}
