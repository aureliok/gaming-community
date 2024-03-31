namespace GamingCommunity.Models
{
    public class VoteAggCountViewModel
    {
        public int? Id { get; set; }
        public string ContentType { get ; set; }
        public int UpvoteCount { get; set; }
        public int DownvoteCount { get; set; }
    }
}
