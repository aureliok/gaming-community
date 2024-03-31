namespace GamingCommunity.Models
{
    public class GameReviewViewModel
    {
        public int ReviewId { get; set; }
        public string ReviewContent { get; set; }
        public string ReviewGame { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
