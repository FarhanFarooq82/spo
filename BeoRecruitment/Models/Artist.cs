using System.Text.Json.Serialization;

public class SpotifySearchResponse
{
    [JsonPropertyName("artists")]
    public ArtistsContainer Artists { get; set; }
}

public class ArtistsContainer
{
    [JsonPropertyName("items")]
    public List<Artist> Items { get; set; }
}

public class Artist
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}

