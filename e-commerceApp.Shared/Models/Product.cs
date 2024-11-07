using e_commerceApp.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace e_commerceApp.Shared.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Category Cartegory { get; set; }
        public string CartegoryId { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ProductStatus ProductStatus { get; set; }
        //Relationship

        public List<Review> Reviews { get; set; }
        //public List<OrderItem> OrderItems { get; set; }

    }
}
