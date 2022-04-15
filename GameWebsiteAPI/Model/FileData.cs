using System.ComponentModel.DataAnnotations;

namespace GameWebsiteAPI.Model
{
    public class FileData
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileExtension { get; set; } = string.Empty;
        public string MimeType { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
    }
}
