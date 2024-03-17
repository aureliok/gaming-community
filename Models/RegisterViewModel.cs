using System.ComponentModel.DataAnnotations;

namespace GamingCommunity.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Birthdate is required.")]
        public DateOnly BirthDate { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
