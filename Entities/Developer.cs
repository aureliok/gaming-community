using System.ComponentModel.DataAnnotations.Schema;

namespace GamingCommunity.Entities
{
    public class Developer
    {
        public int DeveloperId { get; }
        public string DeveloperName { get; set; }
    }
}
