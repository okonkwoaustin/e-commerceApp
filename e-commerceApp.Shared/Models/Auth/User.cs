

using Microsoft.AspNetCore.Identity;

namespace e_commerceApp.Shared.Models.Auth
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<OrderHeader> OrderHeaders { get; set; } = new List<OrderHeader>();
    }
}
