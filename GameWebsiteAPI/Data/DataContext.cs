using GameWebsiteAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GameWebsiteAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<AdminProfile> AdminProfile { get; set; }
        public DbSet<GameSellerProfile> GameSellerProfile { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<FileData> FileData { get; set; }
        public DbSet<GameList> GameList { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
