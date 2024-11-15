using e_commerceApp.Shared.Models.Auth;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerceApp.Shared.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
        public int Count { get; set; }
        public string ShoppingCartId { get; set; }
        [ForeignKey("ShoppingCartId")]
        [ValidateNever]
        public Cart Cart { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
