using WebAPI.Domain.Models;

namespace WebAPI.Domain.Abstractions
{
    public interface IVideoService
    {
        public Task<List<Video>> GetVideos();
        public Task<Guid> Create(Video video);
        public Task<Guid> Delete(Guid id);
        public Task<Guid> Update(Guid id, string name, int duration, string url);
    }
}
