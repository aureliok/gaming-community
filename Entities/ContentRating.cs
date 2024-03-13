namespace GamingCommunity.Entities
{
    public class ContentRating
    {
        public int ContentRatingId { get; }
        public string ContentRatingName { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
