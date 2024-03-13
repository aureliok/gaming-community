namespace GamingCommunity.Entities
{
    public class GameReview
    {
        public int ReviewId { get; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public string ReviewText { get; set; }
    }
}
