namespace YouTubeSessionGenerator.BotGuard;

/// <summary>
/// Represents the JavaScript interpreter details used by BotGuard.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BotGuardInterpreterJs"/> class.
/// </remarks>
/// <param name="privateDoNotAccessOrElseSafeScriptWrappedValue">The internal wrapped value representing a safe script.</param>
/// <param name="privateDoNotAccessOrElseTrustedResourceUrlWrappedValue">The internal wrapped value representing a trusted resource URL.</param>
internal class BotGuardInterpreterJs(
    string privateDoNotAccessOrElseSafeScriptWrappedValue,
    string? privateDoNotAccessOrElseTrustedResourceUrlWrappedValue)
{
    /// <summary>
    /// The internal wrapped value representing a safe script.
    /// </summary>
    public string PrivateDoNotAccessOrElseSafeScriptWrappedValue { get; set; } = privateDoNotAccessOrElseSafeScriptWrappedValue;

    /// <summary>
    /// The internal wrapped value representing a trusted resource URL.
    /// </summary>
    public string? PrivateDoNotAccessOrElseTrustedResourceUrlWrappedValue { get; set; } = privateDoNotAccessOrElseTrustedResourceUrlWrappedValue;
}