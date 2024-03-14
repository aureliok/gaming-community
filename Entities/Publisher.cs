using System.ComponentModel.DataAnnotations.Schema;

namespace GamingCommunity.Entities
{
    public class Publisher
    {
        public int PublisherId { get; }
        public string PublisherName { get; set; }
    }
}
