namespace GamingCommunity.Entities
{
    public class Game
    {
        public int GameId { get; }
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public ICollection<Genre> Genre { get; set; }
        public ICollection<Platform> Platform { get; set; }
        public Developer Developer { get; set; }
        public Publisher Publisher { get; set; }
        public ContentRating ContentRating { get; set; }
        public string ImageId { get; set; }
        public GameReview GameReview { get; set; }
    }
}
