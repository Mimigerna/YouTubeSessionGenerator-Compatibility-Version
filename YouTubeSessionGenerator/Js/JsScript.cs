namespace YouTubeSessionGenerator.Js;

/// <summary>
/// Represents a JavaScript script to be executed in a JavaScript environment,
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="JsScript"/> class.
/// </remarks>
/// <param name="code">The JavaScript code to execute.</param>
/// <param name="args">An optional array of arguments that can be referenced within the script using <c>args</c>.</param>
public class JsScript(
    string code,
    object[]? args = null)
{
    /// <summary>
    /// The JavaScript code to execute.
    /// </summary>
    public string Code { get; set; } = code;

    /// <summary>
    /// The arguments that will be available to the script as the <c>args</c> variable.
    /// </summary>
    public object[] Args { get; set; } = args ?? [];
}