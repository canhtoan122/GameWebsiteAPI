using System.ComponentModel.DataAnnotations;

namespace GameWebsiteAPI.Model
{
    public class AdminProfile
    {
        [Key]
        public int Admin_ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
