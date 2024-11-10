using e_commerceApp.Shared.Models;

namespace e_commerceApp.Application.Services.Interface
{
    public interface IOrderService
    {
        //Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole);
        Task<List<OrderHeader>> GetOrderByUserIdAndRoleAsync(int userId, string userRole);
        Task StoreOrderAsync(List<ShoppingCartItem> items, int userId, string userEmailAddress);
        Task<string> CreateStripeCheckoutSessionAsync(int orderId);
        Task<int> PaymentConfirmation(int orderHeaderid);
        Task<bool> CancelOrderAsync(int orderId);

    }
}
