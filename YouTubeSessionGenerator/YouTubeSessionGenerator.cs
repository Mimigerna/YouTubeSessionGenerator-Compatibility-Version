using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using YouTubeSessionGenerator.BotGuard;
using YouTubeSessionGenerator.Utils;

namespace YouTubeSessionGenerator;

/// <summary>
/// Contains methods to generate valid trusted sessions for YouTube including Visitor Data, Proof of Origin Tokens &amp; Rollout Tokens.
/// </summary>
public class YouTubeSessionGenerator
{
    readonly BotGuardClient? botGuardClient;

    /// <summary>
    /// Creates a new instance of the <see cref="YouTubeSessionGenerator"/> class.
    /// </summary>
    /// <param name="config">The configuration for this YouTube session generator</param>
    public YouTubeSessionGenerator(
        YouTubeSessionConfig? config = null)
    {
        Config = config ?? new YouTubeSessionConfig();

        if (Config.JsEnvironment is not null)
            botGuardClient = new(Config.JsEnvironment, Config.Logger);
    }


    /// <summary>
    /// The configuration for this YouTube session generator.
    /// </summary>
    public YouTubeSessionConfig Config { get; }


    /// <summary>
    /// Generates a valid Proof of Origin Token (PoToken) for a YouTube session.
    /// </summary>
    /// <param name="cancellationToken">The token to cancel this task.</param>
    /// <returns>The valid Proof of Origin Token.</returns>
    /// <exception cref="HttpRequestException">Occurs when the HTTP request fails.</exception>"
    /// <exception cref="JsonException">Occurs when the JSON could not be deseriealized.</exception>"
    /// <exception cref="OperationCanceledException">Occurs when this task was cancelled.</exception>
    public async Task<string> CreateProofOfOriginTokenAsync(
        CancellationToken cancellationToken = default)
    {
        // Create BotGuard challenge
        Config.Logger?.LogInformation("[YouTubeSessionGenerator-CreateProofOfOriginTokenAsync] Creating BotGuard challenge...");

        HttpRequestMessage challengeRequest = new(HttpMethod.Post, Endpoints.CreateUrl)
        {
            Content = new StringContent($"[ \"{Keys.RequestKey}\" ]", Encoding.UTF8, "application/json+protobuf"),
            Headers =
            {
                { "x-goog-api-key", Keys.GoogleApiKey },
                { "x-user-agent", Keys.GoogleUserAgent }
            }
        };
        HttpResponseMessage challengeResponse = await Config.HttpClient.SendAsync(challengeRequest, cancellationToken);

        challengeResponse.EnsureSuccessStatusCode();
        string challengeResponseBody = await challengeResponse.Content.ReadAsStringAsync();

        BotGuardChallenge challenge = BotGuardChallenge.Parse(challengeResponseBody);

        // Prepare JS environment
        Config.Logger?.LogInformation("[YouTubeSessionGenerator-CreateProofOfOriginTokenAsync] Preparing JavaScript environment...");

        if (botGuardClient is null)
            throw new InvalidOperationException("JavaScript environment is not configured.");

        await botGuardClient.LoadAsync(challenge.InterpreterJs.PrivateDoNotAccessOrElseSafeScriptWrappedValue, challenge.Program, challenge.GlobalName);
        string botguardResponse = await botGuardClient.SnapshotAsync();


        // Retrieving Integrity Token
        Config.Logger?.LogInformation("[YouTubeSessionGenerator-CreateProofOfOriginTokenAsync] Retrieving Integrity Token...");

        HttpRequestMessage itRequest = new(HttpMethod.Post, Endpoints.GenerateItUrl)
        {
            Content = new StringContent($"[\"{Keys.RequestKey}\", \"{botguardResponse}\"]", Encoding.UTF8, "application/json+protobuf"),
            Headers =
            {
                { "x-goog-api-key", Keys.GoogleApiKey },
                { "x-user-agent", Keys.GoogleUserAgent },
            }
        };
        HttpResponseMessage itResponse = await Config.HttpClient.SendAsync(itRequest);

        itResponse.EnsureSuccessStatusCode();
        string itResponseBody = await itResponse.Content.ReadAsStringAsync();

        JsonArray itResponseRawData = JsonSerializer.Deserialize<JsonArray>(itResponseBody) ?? throw new InvalidOperationException("Failed to deserialize integrity token.");
        string integrityToken = itResponseRawData[0]?.GetValue<string>() ?? throw new InvalidOperationException("Integrity token is null.");

        return "";
    }
}