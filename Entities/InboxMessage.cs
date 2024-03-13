namespace GamingCommunity.Entities
{
    public class InboxMessage
    {
        public int MessageId { get; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public string MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
