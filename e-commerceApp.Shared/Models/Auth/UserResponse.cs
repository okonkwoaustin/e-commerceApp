using Microsoft.AspNetCore.Identity;

namespace e_commerceApp.Shared.Models.Auth
{
    public class UserResponse
    {
        public string Token { get; set; }
        public IdentityUser User { get; set; }
    }
}
