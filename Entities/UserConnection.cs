namespace GamingCommunity.Entities
{
    public class UserConnection
    {
        public int ConnectionId { get; }
        public User User { get; set; }
        public User FriendUser { get; set; }
        public string ConnectionType { get; set; }
        public DateOnly ConnectionStart { get; set; }
        public DateOnly ConnectionEd { get; set; }
    }
}
