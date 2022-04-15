namespace GameWebsiteAPI.Model
{
    public class AdminRegister
    {
        public string admin_username { get; set; } = string.Empty;
        public byte[] admin_passwordHash { get; set; }
        public byte[] admin_passwordSalt { get; set; }
    }
}
