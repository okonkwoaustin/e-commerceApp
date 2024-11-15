using e_commerceApp.Shared.Enum;
using e_commerceApp.Shared.Models;

namespace e_commerceApp.Application.Dto
{
    public class CreateProduct
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CartegoryId { get; set; }
        public Guid StockQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }

    public class UpdateProduct
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CartegoryId { get; set; }
        public Guid StockQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}
