using System.ComponentModel.DataAnnotations;

namespace GameWebsiteAPI.Model
{
    public class GameList
    {
        [Key]
        public int Game_ID { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public GameSellerProfile? GameSellerProfile { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}
