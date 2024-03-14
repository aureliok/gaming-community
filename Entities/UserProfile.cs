namespace GamingCommunity.Entities
{
    public class UserProfile
    {
        public int UserProfileId { get; }
        public string Bio { get; set; }
        public string AvatarId { get; set; }
        public string GamingPlatformLink { get; set; }
        public User User { get; set; }
    }
}
