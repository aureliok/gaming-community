namespace GamingCommunity.Entities
{
    public class Comment
    {
        public int CommentId { get; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public GamingThread GamingThread { get; set; }
    }
}
