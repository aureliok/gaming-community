namespace GamingCommunity.Models
{
    public class GamingThreadViewModel
    {
        public int ThreadId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Username { get; set; }
        public int CommentsCount { get; set; }
    }
}
