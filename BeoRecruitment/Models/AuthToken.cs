using System.Text.Json.Serialization;

public class AuthToken
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonIgnore]
    public DateTime ExpirationTime { get; set; }

    [JsonIgnore]
    public bool IsExpired => DateTime.UtcNow >= ExpirationTime;
}