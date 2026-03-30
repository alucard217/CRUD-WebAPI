using WebAPI.Domain.Models;

namespace WebAPI.Domain.Abstractions
{
    public interface IVideosRepository
    {
        Task<Guid> Create(Video video);
        Task<Guid> Delete(Guid id);
        Task<List<Video>> Get();
        Task<Guid> Update(Guid id, string name, int duration, string url);
    }
}