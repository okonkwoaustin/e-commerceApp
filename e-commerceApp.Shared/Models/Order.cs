using e_commerceApp.Shared.Enum;
using e_commerceApp.Shared.Models.Auth;

namespace e_commerceApp.Shared.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public User User { get; set; }
    }
}
