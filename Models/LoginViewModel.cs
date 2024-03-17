using System.ComponentModel.DataAnnotations;

namespace GamingCommunity.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username or email is required")]
        public string UsernameOrEmail { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
