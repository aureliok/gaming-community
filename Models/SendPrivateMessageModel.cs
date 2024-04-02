using System.Text.Json.Serialization;

namespace GamingCommunity.Models
{
    public class SendPrivateMessageModel
    {
        public int OtherId { get; set; }
        public string Content { get; set; } 
    }
}
