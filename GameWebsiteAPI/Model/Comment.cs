using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameWebsiteAPI.Model
{
    public class Comment
    {
        [Key]
        public int Comment_ID { get; set; }
        public string CommentContent { get; set; } = string.Empty;
        public UserProfile? UserProfile { get; set; }
        public GameSellerProfile? GameSellerProfile { get; set; }
    }
}
