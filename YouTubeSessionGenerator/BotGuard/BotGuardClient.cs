using Microsoft.Extensions.Logging;
using YouTubeSessionGenerator.Js;
using YouTubeSessionGenerator.Utils;

namespace YouTubeSessionGenerator.BotGuard;

/// <summary>
/// Represents a client for interacting with the BotGuard anti bot system.
/// </summary>
/// <remarks>
/// Creates a new instance of the <see cref="BotGuardClient"/> class.
/// </remarks>
/// <param name="jsEnvironment">The JavaScript environment used to interact with BotGuard.</param>
/// <param name="logger">The logger used to provide progress and error messages.</param>
internal class BotGuardClient(
    IJsEnvironment jsEnvironment,
    ILogger? logger = null)
{
    readonly IJsEnvironment jsEnvironment = jsEnvironment;
    readonly ILogger? logger = logger;


    /// <summary>
    /// Loads the VM functions into the JavaScript environment.
    /// </summary>
    /// <param name="interpreterJs">The internal wrapped value representing a safe script.</param>
    /// <param name="program">The challenge program.</param>
    /// <param name="globalName">The name of the VM in the global scope.</param>
    /// <exception cref="JsException">Occurs when the JavaScript environment throws an error.</exception>
    public async Task LoadAsync(
        string interpreterJs,
        string program,
        string globalName)
    {
        logger?.LogInformation("[BotGuardClient-LoadAsync] Loading VM functions into the JavaScript environment...");

        JsScript interpreterScript = new(interpreterJs);
        await jsEnvironment.ExecuteAsync(interpreterScript);

        JsScript initScript = new($$"""
            const globalObject = globalThis || window;
            const vm = globalObject["{{globalName}}"];

            var vmFunctions = { };
            const snapFunction = vm.a(
                "{{program}}",
                (asyncSnapshotFunction, shutdownFunction, passEventFunction, checkCameraFunction) => {
                    vmFunctions = {
                        asyncSnapshot: asyncSnapshotFunction,
                        shutdown: shutdownFunction,
                        passEvent: passEventFunction,
                        checkCamera: checkCameraFunction
                    };
                },
                true,
                undefined,
                () => { },
                [ [], [] ])[0];
            """);
        await jsEnvironment.ExecuteAsync(initScript);
    }

    /// <summary>
    /// Creates a snapshot of the BotGuard instance.
    /// </summary>
    /// <param name="contentBinding">The content to which the snapshout is bound.</param>
    /// <param name="signedTimestamp">The timestamp of the sign.</param>
    /// <param name="skipPrivacyBuffer">Weither to skip the privacy buffer.</param>
    /// <returns>The snapshot result.</returns>
    /// <exception cref="BotGuardException">Occurs when the snapshot function failes to produce a result</exception>
    /// <exception cref="JsException">Occurs when the JavaScript environment throws an error.</exception>
    public async Task<string> SnapshotAsync(
        BotGuardContentBinding? contentBinding = null,
        object? signedTimestamp = null,
        bool? skipPrivacyBuffer = null)
    {
        logger?.LogInformation("[BotGuardClient-SnapshotAsync] Creating a snapshot...");

        JsScript script = new("""
            const webPoSignalOutput = [];

            snapFunction([ args[0], args[1], webPoSignalOutput, args[2] ]);
            """, [ contentBinding, signedTimestamp, skipPrivacyBuffer ]);

        string? result = await jsEnvironment.ExecuteAsync(script);
        if (result is null)
            logger.LogErrorAndThrow(new BotGuardException("Snapshot function failed to produce a result."), "[BotGuardClient-SnapshotAsync] Failed to create the snapshot.");

        return result;
    }
}