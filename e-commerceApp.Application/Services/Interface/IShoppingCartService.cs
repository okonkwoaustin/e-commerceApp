using e_commerceApp.Shared.Models;

namespace e_commerceApp.Application.Services.Interface
{
    public interface IShoppingCartService
    {
        List<ShoppingCartItem> GetShoppingCartItems();
        void AddItemToCart(Product product);
        void RemoveItemFromCart(Product product);
        decimal GetShoppingCartTotal();
        Task ClearShoppingCartAsync();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
