using System.ComponentModel.DataAnnotations.Schema;

namespace GamingCommunity.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; }
        public string Username { get; set; }
        public string Email { get; set; } 
        public string PasswordHash { get; set; }
        public int LevelId { get; set; }
    }
}
