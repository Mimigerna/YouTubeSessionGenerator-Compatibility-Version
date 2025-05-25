namespace YouTubeSessionGenerator.BotGuard;

/// <summary>
/// Represents the content binding information used in BotGuard snapshots.
/// </summary>
public class BotGuardContentBinding
{
    /// <summary>
    /// Creates a new instance of the <see cref="BotGuardContentBinding"/> class.
    /// </summary>
    /// <param name="c">The 'c' parameter.</param>
    /// <param name="e">The 'e' content binding type.</param>
    /// <param name="encryptedVideoId">The encrypted video identifier.</param>
    /// <param name="externalChannelId">The external channel identifier.</param>
    /// <param name="commentId">The comment identifier.</param>
    /// <param name="atrChallenge">The ATR challenge string.</param>
    /// <param name="additionalProperties">Any additional properties that are not explicitly defined.</param>
    public BotGuardContentBinding(string? c, string? e, string? encryptedVideoId, string? externalChannelId, string? commentId, string? atrChallenge, Dictionary<string, object>? additionalProperties)
    {
        C = c;
        E = e;
        EncryptedVideoId = encryptedVideoId;
        ExternalChannelId = externalChannelId;
        CommentId = commentId;
        AtrChallenge = atrChallenge;
        AdditionalProperties = additionalProperties;
    }

    /// <summary>
    /// The 'c' parameter.
    /// </summary>
    public string? C { get; set; }

    /// <summary>
    /// The 'e' content binding type.
    /// </summary>
    public string? E { get; set; }

    /// <summary>
    /// The encrypted video identifier.
    /// </summary>
    public string? EncryptedVideoId { get; set; }

    /// <summary>
    /// The external channel identifier.
    /// </summary>
    public string? ExternalChannelId { get; set; }

    /// <summary>
    /// The comment identifier.
    /// </summary>
    public string? CommentId { get; set; }

    /// <summary>
    /// The ATR challenge string.
    /// </summary>
    public string? AtrChallenge { get; set; }

    /// <summary>
    /// Any additional properties that are not explicitly defined.
    /// </summary>
    public Dictionary<string, object>? AdditionalProperties { get; set; }
}