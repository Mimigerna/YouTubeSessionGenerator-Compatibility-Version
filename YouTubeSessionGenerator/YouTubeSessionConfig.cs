using Microsoft.Extensions.Logging;
using YouTubeSessionGenerator.Js;

namespace YouTubeSessionGenerator;

/// <summary>
/// Contains configuration options for the YouTube session generator.
/// </summary>
public class YouTubeSessionConfig
{
    /// <summary>
    /// The JavaScript environment used to execute scripts for generating PoTokens.
    /// </summary>
    public IJsEnvironment? JsEnvironment { get; init; }


    HttpClient? httpClient = null;
    /// <summary>
    /// The HTTP client used to send requests to YouTube.
    /// </summary>
    public HttpClient HttpClient
    {
        get => httpClient ??= new();
        init => httpClient = value;
    }

    /// <summary>
    /// The logger used to provide progress and error messages.
    /// </summary>
    public ILogger? Logger { get; init; }
}