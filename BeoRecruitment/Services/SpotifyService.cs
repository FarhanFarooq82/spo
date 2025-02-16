using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;



public class SpotifyService : ISpotifyService
{
    private readonly HttpClient _httpClient;
    private readonly HttpClient authClient;
    private readonly string _clientId = "aae368d1daac4561af4600d1bfeb3a4f";
    private readonly string _clientSecret = "c7a7b72a78104a49a607b2480cbb8587";
    private AuthToken _currentToken;

    public SpotifyService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.spotify.com/v1/")
        };
        authClient = new HttpClient
        {
            BaseAddress = new Uri("https://accounts.spotify.com/api/")
        };
    }

    private async Task EnsureAccessTokenAsync()
    {
        // First quick check for the token availability
        if (_currentToken == null || _currentToken.IsExpired)
        {
            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));

            var request = new HttpRequestMessage(HttpMethod.Post, "token")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "grant_type", "client_credentials" }
                })
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            var response = await authClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to obtain access token. Status: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<AuthToken>(content);

            // Set expiration time (subtracting 30 seconds as safety margin)
            tokenResponse.ExpirationTime = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn - 30);
            _currentToken = tokenResponse;
        }

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _currentToken.AccessToken);
        return;
    }

    public async Task<IReadOnlyList<Artist>> SearchArtistsAsync(string searchTerm)
    {
        await EnsureAccessTokenAsync();
        var response = await _httpClient.GetAsync($"search?q={Uri.EscapeDataString(searchTerm)}&type=artist");
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Failed to obtain Spotify access token. Status: {response.StatusCode}");
        }

        var content = await response.Content.ReadAsStringAsync();
        var searchResponse = JsonSerializer.Deserialize<SpotifySearchResponse>(content);

        return searchResponse?.Artists?.Items ?? new List<Artist>();
    }



}