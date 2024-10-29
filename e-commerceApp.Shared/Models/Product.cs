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
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ProductStatus ProductStatus { get; set; }
        //Relationship
        public List<ActorMovie> ActorMovies { get; set; }
        //Cinema
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        //Producer
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}
