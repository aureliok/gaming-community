namespace GamingCommunity.Entities
{
    public class UserConnection
    {
        public int ConnectionId { get; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public string ConnectionType { get; set; }
        public DateOnly ConnectionStart { get; set; }
        public DateOnly ConnectionEd { get; set; }
    }
}
