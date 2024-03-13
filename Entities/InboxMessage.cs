namespace GamingCommunity.Entities
{
    public class InboxMessage
    {
        public int MessageId { get; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
