namespace YouTubeSessionGenerator.BotGuard;

/// <summary>
/// Represents an exception that occurs during the execution of BotGuard related operations.
/// </summary>
public class BotGuardException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BotGuardException"/> class.
    /// </summary>
    public BotGuardException()
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BotGuardException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public BotGuardException(
        string message) : base(message)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BotGuardException"/> class.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public BotGuardException(
        string message,
        Exception innerException) : base(message, innerException)
    { }
}