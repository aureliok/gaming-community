using System.ComponentModel.DataAnnotations.Schema;

namespace GamingCommunity.Entities
{
    public class Game
    {
        public int GameId { get; }
        public string Title { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public int PlatformId { get; set; }
        public int DeveloperId { get; set; }
        public int PublisherId { get; set; }
        public int ContentRatingId { get; set; }
        public string? ImageId { get; set; }
    }
}
