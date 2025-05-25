using System.Diagnostics;
using System.Text.Json;

namespace YouTubeSessionGenerator.Js;

/// <summary>
/// Represents an execution environment capable of running JavaScript code powered by a Node.js process.
/// </summary>
/// <remarks>
/// Requires Node.js to be installed and available in the system PATH.
/// Only works on platforms which allow spawning external untime processes, such as Windows, Linux, and macOS.
/// </remarks>
public class NodeEnvironment : IJsEnvironment
{
    const string ServerScript = """
        const vm = require('vm');
        const readline = require("readline");

        const context = vm.createContext({});
        const rl = readline.createInterface({
            input: process.stdin,
            output: process.stdout,
            terminal: false
        });

        rl.on("line", async (line) => {
            try {
                const script = JSON.parse(line);
                const code = script.Code;
                const args = script.Args;
        
                context.args = args;
                const scriptToRun = new vm.Script(code);

                const result = await scriptToRun.runInContext(context);
                console.log(JSON.stringify({ result }));
            } catch (error) {
                console.log(JSON.stringify({ error: error.message }));
            }
        });
        """;


    readonly Process node;
    readonly StreamWriter input;
    readonly StreamReader output;

    /// <summary>
    /// Initializes a new instance of the <see cref="NodeEnvironment"/> class and starts a Node.js process.
    /// </summary>
    /// <exception cref="JsException">Thrown if the JavaScript code throws an error.</exception>
    public NodeEnvironment()
    {
        node = new()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "node",
                Arguments = $"-e \"{ServerScript
                    .Replace("\\", "\\\\")
                    .Replace("\"", "\\\"")
                    .Replace("\r", "")}\"",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        node.ErrorDataReceived += (sender, e) => {
            if (!string.IsNullOrEmpty(e.Data))
                throw new JsException($"Node Environment STDERR: {e.Data}");
        };

        node.Start();

        input = node.StandardInput;
        output = node.StandardOutput;
    }


    bool isDisposed = false;

    /// <summary>
    /// Finalizes an instance of the <see cref="NodeEnvironment"/> class.
    ///  </summary>
    ~NodeEnvironment()
    {
        Dispose(false);
    }


    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="NodeEnvironment"/> and optionally releases managed resources.
    /// </summary>
    /// <param name="disposing"><see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.</param>
    protected virtual void Dispose(
        bool disposing)
    {
        if (isDisposed)
            return;

        if (disposing)
        {
            try
            {
                JsScript script = new("process.exit();");
                string json = JsonSerializer.Serialize(script);

                input.WriteLine(json);
                input.Flush();
            }
            catch
            { }

            node.WaitForExit(1000);

            input?.Dispose();
            output?.Dispose();
            node?.Dispose();
        }

        isDisposed = true;
    }

    /// <summary>
    /// Releases all resources used by the current instance of the <see cref="NodeEnvironment"/> class and shuts down the Node.js process.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


    /// <summary>
    /// Executes the specified JavaScript code asynchronously in the Node.js environment.
    /// </summary>
    /// <param name="script">The <see cref="JsScript"/> to execute.</param>
    /// <returns>
    /// The result as a JSON-serializable string or <c>null</c> if no result was produced.
    /// </returns>
    /// <exception cref="JsException">Thrown if the JavaScript code throws an error.</exception>
    public async Task<string?> ExecuteAsync(
        JsScript script)
    {
        string json = JsonSerializer.Serialize(script);

        await input.WriteLineAsync(json);
        await input.FlushAsync();

        string? line = await output.ReadLineAsync();
        if (line is null)
            return null;

        using JsonDocument doc = JsonDocument.Parse(line);
        if (doc.RootElement.TryGetProperty("error", out JsonElement error))
            throw new JsException(error.GetString() ?? "Unknown JavaScript error.", script);

        return doc.RootElement.TryGetProperty("result", out JsonElement result) ? result.ToString() : null;
    }
}