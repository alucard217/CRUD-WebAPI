using WebAPI.Domain.Models;
using WebAPI.Domain.Abstractions;
using WebAPI.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.DataAccess.Repositories
{
    public class VideosRepository : IVideosRepository
    {
        private readonly VideoStoreDbContext _context;
        public VideosRepository(VideoStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Video>> Get()
        {
            var videoEntities = await _context.Videos.ToListAsync(); // AsNoTracking()
            var videos = videoEntities
                .Select(video => Video.Create(video.Id, video.Name, video.Duration, video.Url).Item1)
                .ToList();
            return videos;
        }
        public async Task<Guid> Create(Video video)
        {
            var videoEntity = new VideoEntity
            {
                Id = video.Id,
                Name = video.Name,
                Duration = video.Duration,
                Url = video.Url
            };
            await _context.Videos.AddAsync(videoEntity);
            await _context.SaveChangesAsync();
            return videoEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, int duration, string url)
        {
            await _context.Videos
                .Where(v => v.Id == id)
                .ExecuteUpdateAsync(v => v
                .SetProperty(v => v.Name, v => name)
                .SetProperty(v => v.Duration, v => duration)
                .SetProperty(v => v.Url, v => url)
                );
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Videos
                .Where(v => v.Id == id).ExecuteDeleteAsync();
            return id;
        }
    }
}
