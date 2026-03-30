namespace WebAPI.DataAccess.Entities
{
    public class VideoEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Duration { get; set; }

        public required string Url { get; set; } 
    }
}
