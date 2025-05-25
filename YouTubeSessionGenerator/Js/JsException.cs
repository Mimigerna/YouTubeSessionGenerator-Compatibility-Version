namespace YouTubeSessionGenerator.Js;

/// <summary>
/// Represents an exception that occurs during the execution of JavaScript code within a JS environment.
/// </summary>
public class JsException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="JsException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message returned by the JavaScript engine.</param>
    /// <param name="script">The original JavaScript script which caused the exception.</param>
    public JsException(
        string message,
        JsScript? script = null) : base(message)
    {
        Script = script;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="JsException"/> class with a specified error message and inner exception.
    /// </summary>
    /// <param name="message">The message returned by the JavaScript engine.</param>
    /// <param name="script">The original JavaScript script which caused the exception.</param>
    /// <param name="innerException">The exception that is the cause of this exception.</param>
    public JsException(
        string message,
        Exception innerException,
        JsScript? script = null) : base(message, innerException)
    {
        Script = script;
    }


    /// <summary>
    /// The original JavaScript script which caused the exception.
    /// </summary>
    public JsScript? Script { get; }
}