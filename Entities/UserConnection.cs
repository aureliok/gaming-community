using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GamingCommunity.Entities
{
    public enum ConnectionType
    {
        friend,
        follower,
        following
    }

    public class UserConnection
    {
        public int ConnectionId { get; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        [EnumDataType(typeof(ConnectionType))]
        public string ConnectionType { get; set; }
        public DateOnly? ConnectionStart { get; set; }
        public DateOnly? ConnectionEnd { get; set; }
    }
}
