namespace GamingCommunity.Entities
{
    public class Comment
    {
        public int CommentId { get; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public int ThreadId { get; set; }
    }
}
