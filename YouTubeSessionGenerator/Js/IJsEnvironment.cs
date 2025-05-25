namespace YouTubeSessionGenerator.Js;

/// <summary>
/// Represents an execution environment capable of running JavaScript code.
/// </summary>
public interface IJsEnvironment : IDisposable
{
    /// <summary>
    /// Executes the specified JavaScript script asynchronously within the environment.
    /// </summary>
    /// <param name="script">The <see cref="JsScript"/> to execute.</param>
    /// <returns>
    /// The result as a JSON-serializable string or <c>null</c> if no result was produced.
    /// </returns>
    /// <exception cref="JsException">Occurs when the JavaScript code throws an error.</exception>
    Task<string?> ExecuteAsync(
        JsScript script);
}
