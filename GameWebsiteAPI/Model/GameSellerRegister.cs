namespace GameWebsiteAPI.Model
{
    public class GameSellerRegister
    {
        public string GameSeller_username { get; set; } = string.Empty;
        public byte[] GameSeller_passwordHash { get; set; }
        public byte[] GameSeller_passwordSalt { get; set; }
    }
}
