using System.ComponentModel.DataAnnotations.Schema;

namespace GamingCommunity.Entities
{
    //[Table("Users", Schema = "community_data")]
    public class User
    {
        public int UserId { get; }
        public string UserName { get; set; }
        public string Email { get; set; } 
        public string PasswordHash { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public UserLevel Level { get; set; }
        public ICollection<GamingThread> GamingThread { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<GameReview> GameReviews { get; set; }
        public ICollection<UserConnection> UserConnections { get; set; }
        public ICollection<InboxMessage> ReceivedMessages { get; set; }
        public ICollection<InboxMessage> SentMessages { get; set; }
    }
}
