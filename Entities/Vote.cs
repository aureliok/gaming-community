using System.ComponentModel.DataAnnotations.Schema;

namespace GamingCommunity.Entities
{
    public class Vote
    {
        public int VoteId { get; }
        public string VoteType { get; set; }
        public int UserId { get; set; }
        public int? ThreadId { get; set; }
        public int? CommentId { get; set; }
        public int? ReviewId { get; set; }
    }
}
