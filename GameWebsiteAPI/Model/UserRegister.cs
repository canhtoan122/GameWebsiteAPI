namespace GameWebsiteAPI.Model
{
    public class UserRegister
    {
        public string user_username { get; set; } = string.Empty;
        public byte[] user_passwordHash { get; set; }
        public byte[] user_passwordSalt { get; set; }
    }
}
