using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameWebsiteAPI.Model
{
    public class Comment
    {
        //public Comment()
        //{
        //    this.UserProfile = new HashSet<UserProfile>();
        //}

        [Key]
        public int Comment_ID { get; set; }
        public string CommentContent { get; set; } = string.Empty;
        public UserProfile? UserProfile { get; set; }
        public GameSellerProfile? GameSellerProfile { get; set; }

        //public virtual ICollection<UserProfile> UserProfile { get; set; }
    }
}
