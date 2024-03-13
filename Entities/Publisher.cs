namespace GamingCommunity.Entities
{
    public class Publisher
    {
        public int PublisherId { get; }
        public string PublisherName { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
