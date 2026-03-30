using WebAPI.Domain.Abstractions;
using WebAPI.Domain.Models;


namespace WebAPI.Application.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideosRepository _videoRepository;
        public VideoService(IVideosRepository videoRepository)
        { 
            _videoRepository = videoRepository;
        }

        public Task<List<Video>> GetVideos()
        {
            return _videoRepository.Get();
        }

        public Task<Guid> Create(Video video)
        {
            return _videoRepository.Create(video);
        }

        public Task<Guid> Delete(Guid id) 
        {
            return _videoRepository.Delete(id);
        }

        public Task<Guid> Update(Guid id, string name, int duration, string url)
        {
            return _videoRepository.Update(id, name, duration, url);
        }


    }
}
