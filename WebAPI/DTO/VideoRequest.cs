namespace WebAPI.DTO
{
    public record VideoRequest(
        string Name,
        int Duration,
        string Url
    );
}
