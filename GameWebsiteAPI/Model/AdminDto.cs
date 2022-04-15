using System.ComponentModel.DataAnnotations;

namespace GameWebsiteAPI.Model
{
    public class AdminDto
    {
        public string admin_username { get; set; } = string.Empty;
        public string admin_password { get; set; } = string.Empty;
    }
}
