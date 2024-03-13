namespace GamingCommunity.Entities
{
    public class GameReview
    {
        public int ReviewId { get; }
        public Game Game { get; set; }
        public User User { get; set; }
        public int Score { get; set; }
        public string ReviewText { get; set; }
    }
}
