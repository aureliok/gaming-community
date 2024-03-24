using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingCommunity.Entities
{
    public class GameReview
    {
        public int ReviewId { get; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        [Range(1,5)]
        public int Score { get; set; }
        public string? ReviewText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
