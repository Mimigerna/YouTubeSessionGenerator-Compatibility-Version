namespace YouTubeSessionGenerator.BotGuard;

/// <summary>
/// Represents the content binding information used in BotGuard snapshots.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BotGuardContentBinding"/> class.
/// </remarks>
/// <param name="c">The 'c' parameter.</param>
/// <param name="e">The 'e' content binding type.</param>
/// <param name="encryptedVideoId">The encrypted video identifier.</param>
/// <param name="externalChannelId">The external channel identifier.</param>
/// <param name="commentId">The comment identifier.</param>
/// <param name="atrChallenge">The ATR challenge string.</param>
/// <param name="additionalProperties">Any additional properties that are not explicitly defined.</param>
public class BotGuardContentBinding(
    string? c = null,
    string? e = null,
    string? encryptedVideoId = null,
    string? externalChannelId = null,
    string? commentId = null,
    string? atrChallenge = null,
    Dictionary<string, object>? additionalProperties = null)
{
    /// <summary>
    /// The 'c' parameter.
    /// </summary>
    public string? C { get; set; } = c;

    /// <summary>
    /// The 'e' content binding type.
    /// </summary>
    public string? E { get; set; } = e;

    /// <summary>
    /// The encrypted video identifier.
    /// </summary>
    public string? EncryptedVideoId { get; set; } = encryptedVideoId;

    /// <summary>
    /// The external channel identifier.
    /// </summary>
    public string? ExternalChannelId { get; set; } = externalChannelId;

    /// <summary>
    /// The comment identifier.
    /// </summary>
    public string? CommentId { get; set; } = commentId;

    /// <summary>
    /// The ATR challenge string.
    /// </summary>
    public string? AtrChallenge { get; set; } = atrChallenge;

    /// <summary>
    /// Any additional properties that are not explicitly defined.
    /// </summary>
    public Dictionary<string, object>? AdditionalProperties { get; set; } = additionalProperties;
}