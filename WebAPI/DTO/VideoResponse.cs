namespace WebAPI.DTO
{
    public record VideoResponse
    (
        Guid id,
        string Name,
        int Duration,
        string Url
    );
}
