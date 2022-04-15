using System.ComponentModel.DataAnnotations;

namespace GameWebsiteAPI.Model
{
    public class GameSellerProfile
    {
        [Key]
        public int GameSeller_ID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public string Ethnic { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Religion { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
