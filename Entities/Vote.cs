namespace GamingCommunity.Entities
{
    public class Vote
    {
        public int VoteId { get; }
        public string VoteType { get; set; }
        public User User { get; set; }
        public GamingThread GamingThread { get; set; }
        public Comment Comment { get; set; }
    }
}
