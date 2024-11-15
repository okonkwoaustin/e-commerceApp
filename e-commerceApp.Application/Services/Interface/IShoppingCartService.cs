using e_commerceApp.Shared.Models;

namespace e_commerceApp.Application.Services.Interface
{
    public interface IShoppingCartService
    {
        List<ShoppingCartItem> GetShoppingCartItems();
        Task AddItemToCart(Product product);
        Task RemoveItemFromCart(Product product);
        decimal GetShoppingCartTotal();
        Task ClearShoppingCartAsync();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
        Task<bool> IncrementItemCountAsync(Guid cartId);
        Task<bool> DecrementItemCountAsync(Guid cartId);

    }
}
