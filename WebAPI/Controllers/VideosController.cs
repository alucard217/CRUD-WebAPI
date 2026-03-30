using WebAPI.Domain.Abstractions;
using WebAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;
        public VideosController(IVideoService videoService) {
            _videoService = videoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoResponse>>> GetVideos() {
            var videos = await _videoService.GetVideos();
            var response = videos.Select(v => new VideoResponse(v.Id, v.Name, v.Duration, v.Url));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> PostVideo(VideoRequest request) {
            var (video, error) = Video.Create(Guid.NewGuid(), request.Name, request.Duration, request.Url);
            if (!string.IsNullOrEmpty(error)) {
                return BadRequest(error);
            }
            await _videoService.Create(video);
            return Ok(video.Id);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateVideo(Guid id, VideoRequest request) {
            var ID = await _videoService.Update(id, request.Name, request.Duration, request.Url);
            return Ok(ID);
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteVideo(Guid id) {
            return Ok(await _videoService.Delete(id));
        }
    }
}

