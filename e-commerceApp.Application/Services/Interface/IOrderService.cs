using e_commerceApp.Shared.Models;

namespace e_commerceApp.Application.Services.Interface
{
    public interface IOrderService
    {
        //Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole);
        Task<List<OrderHeader>> GetOrderByUserIdAndRoleAsync(string userId, string userRole);
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<string> CreateStripeCheckoutSessionAsync(string orderId);
        Task<string> PaymentConfirmation(string orderHeaderid);
        Task<bool> CancelOrderAsync(string orderId);

    }
}
