public interface ISpotifyService
{
    Task<IReadOnlyList<Artist>> SearchArtistsAsync(string searchTerm);
}