using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using YouTubeSessionGenerator.Js;
using YouTubeSessionGenerator.Utils;

namespace YouTubeSessionGenerator.BotGuard;

/// <summary>
/// Represents a client for interacting with the BotGuard anti bot system.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BotGuardClient"/> class.
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
    /// Loads the snapshot functtion into the JavaScript environment.
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
    /// Creates a snapshot for the provided content.
    /// </summary>
    /// <param name="contentBinding">The content to which the snapshout is bound.</param>
    /// <param name="signedTimestamp">The timestamp of the sign.</param>
    /// <param name="skipPrivacyBuffer">Weither to skip the privacy buffer.</param>
    /// <returns>The snapshot.</returns>
    /// <exception cref="BotGuardException">Occurs when the snapshot function failes to produce a result.</exception>
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
            """, [ contentBinding?.Flatten(), signedTimestamp, skipPrivacyBuffer ]);

        string? result = await jsEnvironment.ExecuteAsync(script);
        if (result is null)
            logger.LogErrorAndThrow(new BotGuardException("Snapshot function failed to produce a result."), "[BotGuardClient-SnapshotAsync] Failed to create the snapshot.");

        return result;
    }


    /// <summary>
    /// Loads the minter functtion into the JavaScript environment.
    /// </summary>
    /// <param name="integrityToken">The integrity taken used to mint identifiers.</param>
    /// <exception cref="JsException">Occurs when the JavaScript environment throws an error.</exception>
    public async Task LoadMintAsync(
        byte[] integrityToken)
    {
        logger?.LogInformation("[BotGuardClient-MintAsync] Loading minter using integrity token...");

        JsScript script = new("""
            const mintCallback = webPoSignalOutput[0](args[0]);
            """, [integrityToken.Cast<object>().ToArray()]);
        await jsEnvironment.ExecuteAsync(script);
    }

    /// <summary>
    /// Mints the provided identifier.
    /// </summary>
    /// <param name="identifier">The indentifier to mint.</param>
    /// <returns>The minted token.</returns>
    /// <exception cref="BotGuardException">Occurs when the mint function failes to produce a result.</exception>
    /// <exception cref="JsException">Occurs when the JavaScript environment throws an error.</exception>
    public async Task<byte[]> MintAsync(
        string identifier)
    {
        logger?.LogInformation("[BotGuardClient-SnapshotAsync] Minting identifier...");

        JsScript script = new("""
            mintCallback(args[0]);
            """, [Encoding.UTF8.GetBytes(identifier).Cast<object>().ToArray()]);

        string? result = await jsEnvironment.ExecuteAsync(script);
        if (result is null)
            logger.LogErrorAndThrow(new BotGuardException("Mint function failed to produce a result."), "[BotGuardClient-MintAsync] Failed to mint identifier.");

        Dictionary<string, byte>? bytesData = JsonSerializer.Deserialize<Dictionary<string, byte>>(result) ?? throw new JsonException("Failed to deserialize minted identifier.");
        return [..bytesData.Values];
    }
}