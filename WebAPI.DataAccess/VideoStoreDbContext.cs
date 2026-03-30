using Microsoft.EntityFrameworkCore;

namespace WebAPI.DataAccess
{
    public class VideoStoreDbContext : DbContext
    {
        public VideoStoreDbContext(DbContextOptions<VideoStoreDbContext> options)
        : base(options)
        {
        
        }
        
        public DbSet<Entities.VideoEntity> Videos { get; set; }

    }
}
