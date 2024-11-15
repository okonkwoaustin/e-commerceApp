namespace e_commerceApp.Shared.Models
{
    public class Review
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
        public int Rating { get; set; } 
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
