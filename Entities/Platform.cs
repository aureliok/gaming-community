using System.ComponentModel.DataAnnotations.Schema;

namespace GamingCommunity.Entities
{
    public class Platform
    {
        public int PlatformId { get; }
        public string PlatformName { get; set; }
    }
}
