using System.Text.Json.Serialization;

namespace e_commerceApp.Shared.Models
{
    public class Cart
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? UserId { get; set; } 
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        [JsonIgnore]
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
