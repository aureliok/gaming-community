namespace GamingCommunity.Entities
{
    public class Genre
    {
        public int GenreId { get; }
        public string GenreName { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
