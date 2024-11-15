using Microsoft.AspNetCore.Identity;

namespace e_commerceApp.Shared.Models.Auth
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
