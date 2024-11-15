using System.Text.Json.Serialization;

namespace e_commerceApp.Shared.Models
{
    public class Category
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }

    }

    public class CategoryDto
    {
        public string Id { get; set; } 
        public string Name { get; set; }

        // Only include a list of product IDs, not the full product details
        public List<string> ProductIds { get; set; }
    }
}
