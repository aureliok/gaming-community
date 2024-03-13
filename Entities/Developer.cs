namespace GamingCommunity.Entities
{
    public class Developer
    {
        public int DeveloperId { get; }
        public string DeveloperName { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
