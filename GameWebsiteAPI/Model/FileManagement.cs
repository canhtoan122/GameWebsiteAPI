namespace GameWebsiteAPI.Model
{
    public class FileManagement
    {
        public IFormFile MyFile { get; set; }
        public string AltText { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
