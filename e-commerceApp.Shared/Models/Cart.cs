namespace e_commerceApp.Shared.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
