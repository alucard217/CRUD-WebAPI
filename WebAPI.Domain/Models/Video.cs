namespace WebAPI.Domain.Models
{
    public class Video
    {
        public const int MAX_NAME_LENGTH = 40;

        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public int Duration { get; }

        public string Url { get; }

        private Video(Guid id, string name, int duration, string url)
        {
            Id = id;
            Name = name;
            Duration = duration;
            Url = url;
        }

        public static (Video, string) Create(Guid id, string name, int duration, string url)
        {
            var error = string.Empty;
            var video = new Video(id, name, duration, url);

            if (name.Length > MAX_NAME_LENGTH) {
                error += "Video name can not be more than 40 symbols. ";
            }
            if (duration < 0)
            {
                error += "Video duration can not be 0. ";
            }
            if (url == null)
            {
                error += "Video URL can not be  empty. ";
            }

            return (video, error);
        }
    }
}
