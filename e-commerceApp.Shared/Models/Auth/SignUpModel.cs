using System.ComponentModel.DataAnnotations;

namespace e_commerceApp.Shared.Models.Auth
{
    public class SignUpModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
