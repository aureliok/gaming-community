namespace GamingCommunity.Models
{
    public class InboxMessageReturnViewModel
    {
        public int UserId { get; set; }
        public string MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OtherId { get; set; }
        public string OtherUsername { get; set; }
        public string MessageAuthor { get; set; }
    }
}
