namespace YouTubeSessionGenerator.Utils;

/// <summary>
/// Contains endpoints used in the YouTube session generator.
/// </summary>
internal static class Endpoints
{
    const string YouTubeUrl = "https://www.youtube.com";

    const string YouTubeApiBaseUrl = "https://www.youtube.com/api/jnn/v1";


    /// <summary>
    /// The URL to create a BotGuard challenge.
    /// </summary>
    public const string CreateUrl = YouTubeApiBaseUrl + "/Create";

    /// <summary>
    /// The URL to generate a Proof of Origin Token (PoToken).
    /// </summary>
    public const string GenerateItUrl = YouTubeApiBaseUrl + "/GenerateIT";

    /// <summary>
    /// The URL for an embedded YouTube video.
    /// </summary>
    /// <param name="videoId">The ID of the video to embed.</param>
    /// <returns>The URL to the embedded YouTube video</returns>
    public static string Embed(string videoId) => $"{YouTubeUrl}/embed/{videoId}";
}