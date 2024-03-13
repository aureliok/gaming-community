namespace GamingCommunity.Entities
{
    public class Platform
    {
        public int PlatformId { get; }
        public string PlatformName { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
