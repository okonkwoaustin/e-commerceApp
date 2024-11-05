using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Data;
using e_commerceApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerceApp.Application.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly EcommDbContext _ecommDbContext;
        public OrderService(EcommDbContext ecommDbContext)
        {
            _ecommDbContext = ecommDbContext;
        }
        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _ecommDbContext.Orders.Include(o => o.OrderItems).ThenInclude(u => u.Product).Include(u => u.User).ToListAsync();
            if (userRole != "Admin")
            {
                orders = orders.Where(u => u.CustomerId == userId).ToList();
            }
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                CustomerId = userId,
                Email = userEmailAddress
            };
            await _ecommDbContext.Orders.AddAsync(order);
            await _ecommDbContext.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Quantity = item.Amount,
                    ProductId = item.Product.Id,
                    OrderId = order.Id,
                    UnitPrice = item.Product.Price,
                };
                await _ecommDbContext.OrderItems.AddAsync(orderItem);
                await _ecommDbContext.SaveChangesAsync();
            }
        }

    }
}
