namespace GamingCommunity.Entities
{
    public class User
    {
        public int UserId { get; }
        public string UserName { get; set; }
        public string Email { get; set; } 
        public string PasswordHash { get; set; }
        public UserLevel Level { get; set; }
    }
}
