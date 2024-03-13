namespace GamingCommunity.Entities
{
    public class UserLevel
    {
        public int LevelId { get; }
        public string Level { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
