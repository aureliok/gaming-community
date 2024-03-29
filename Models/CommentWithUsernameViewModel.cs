namespace GamingCommunity.Models
{
    public class CommentWithUsernameViewModel
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Username { get; set; }
    }
}
