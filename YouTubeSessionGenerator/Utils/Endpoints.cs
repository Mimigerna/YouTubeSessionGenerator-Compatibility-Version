namespace YouTubeSessionGenerator.Utils;

/// <summary>
/// Contains endpoints used in the YouTube session generator.
/// </summary>
internal static class Endpoints
{
    /// <summary>
    /// The base URL for the YouTube API.
    /// </summary>
    const string YouTubeApiBaseUrl = "https://www.youtube.com/api/jnn/v1";


    /// <summary>
    /// The URL to create a BotGuard challenge.
    /// </summary>
    public const string CreateUrl = YouTubeApiBaseUrl + "/Create";

    /// <summary>
    /// The URL to generate a Proof of Origin Token (PoToken).
    /// </summary>
    public const string GenerateItUrl = YouTubeApiBaseUrl + "/GenerateIT";
}