namespace e_commerceApp.Shared.Models
{
    public class OrderItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string OrderId { get; set; } 
        public string ProductId { get; set; } 
        public Product Product { get; set; }
        public string Quantity { get; set; } 
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
