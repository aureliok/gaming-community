using System.ComponentModel.DataAnnotations.Schema;

namespace GamingCommunity.Entities
{
    public class ContentRating
    {
        public int ContentRatingId { get; }
        public string ContentRatingName { get; set; }
    }
}
