using e_commerceApp.Shared.Data;
using e_commerceApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerceApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly EcommDbContext _db;

        public OrderController(EcommDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task<ActionResult<OrderItem>> CreateOder(OrderItem salesOrder)
        {
            var productSales = await _db.Products.FindAsync(salesOrder.Id);
            if (productSales == null || productSales.StockQuantity < salesOrder.Quantity)
            {
                return BadRequest("Invalid product or insufficient stock.");
            }

            productSales.StockQuantity -= salesOrder.Quantity;  // each sale decrements stock

            var payment = new PaymentModel         //  The transaction is created, recording the total amount and status.
            {
                CompletedAt = DateTime.Now,
                Amount = (decimal)(productSales.Price * salesOrder.Quantity),
                Status = PaymentModel.PaymentStatus.Pending,
            };

            _db.OrderItems.Add(salesOrder);
            _db.Add(payment);
            // _db.

            await _db.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = salesOrder.Id }, salesOrder);
        }
    }
}

