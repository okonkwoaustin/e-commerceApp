using Microsoft.AspNetCore.Identity;

namespace e_commerceApp.Shared.Models.Auth
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<OrderHeader> OrderHeaders { get; set; } = new List<OrderHeader>();
        public bool IsActive { get; set; } = true;
    }
}
