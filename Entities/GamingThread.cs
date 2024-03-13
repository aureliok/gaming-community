namespace GamingCommunity.Entities
{
    public class GamingThread
    {
        public int ThreadId { get; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
    }
}
