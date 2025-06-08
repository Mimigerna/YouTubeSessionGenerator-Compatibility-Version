using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using YouTubeSessionGenerator.Utils;

namespace YouTubeSessionGenerator.BotGuard;

/// <summary>
/// Represents a BotGuard challenge containing all necessary information to process it.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="BotGuardChallenge"/> class.
/// </remarks>
/// <param name="messageId">The ID of the JSPB message.</param>
/// <param name="interpreterHash">The hash of the script. Useful if you want to fetch the challenge script again at a later time.</param>
/// <param name="program">The challenge program.</param>
/// <param name="globalName">The name of the VM in the global scope.</param>
/// <param name="clientExperimentsStateBlob">The client experiments state blob.</param>
/// <param name="interpreterJs">The script associated with the challenge.</param>
internal class BotGuardChallenge(
    string messageId,
    string interpreterHash,
    string program,
    string globalName,
    string clientExperimentsStateBlob,
    BotGuardInterpreterJs interpreterJs)
{
    /// <summary>
    /// Parses the raw JSON data from a BotGuard challenge response.
    /// </summary>
    /// <param name="json">The raw JSON data.</param>
    /// <returns>The parsed BotGuard challenge</returns>
    /// <exception cref="BotGuardException">Occurs when some value is missing from the raw JSON data.</exception>
    public static BotGuardChallenge Parse(
        string json)
    {
        JsonArray rawData = JsonSerializer.Deserialize<JsonArray>(json) ?? throw new BotGuardException("Failed to deserialize BotGuard challenge.");
        
        JsonArray? challengeData = null;
        if (rawData[1]?.GetValue<string>() is string str)
        {
            byte[] buffer = str.ToBytesFromBase64();
            byte[] descrambled = [.. buffer.Select(b => (byte)(b + 97))];
            string unscrambled = Encoding.UTF8.GetString(descrambled);

            challengeData = JsonSerializer.Deserialize<JsonArray>(unscrambled);
        }
        else if (rawData[0]?.AsArray() is JsonArray obj)
        {
            challengeData = obj;
        }

        if (challengeData is null || challengeData.Count < 7)
            throw new BotGuardException("Failed to deserialize BotGuard challange.");

        return new(
            messageId: challengeData[0]?.GetValue<string>() ?? throw new BotGuardException("Failed to deserialize BotGuard challange: 'MessageId' is null."),
            interpreterHash: challengeData[3]?.GetValue<string>() ?? throw new BotGuardException("Failed to deserialize BotGuard challange: 'InterpreterHash' is null."),
            program: challengeData[4]?.GetValue<string>() ?? throw new BotGuardException("Failed to deserialize BotGuard challange: 'Program' is null."),
            globalName: challengeData[5]?.GetValue<string>() ?? throw new BotGuardException("Failed to deserialize BotGuard challange: 'GlobalName' is null."),
            clientExperimentsStateBlob: challengeData[7]?.GetValue<string>() ?? throw new BotGuardException("Failed to deserialize BotGuard challange: 'ClientExperimentsStateBlob' is null."),
            interpreterJs: new(
                privateDoNotAccessOrElseSafeScriptWrappedValue: challengeData[1]?.AsArray().FindFirstString() ?? throw new BotGuardException("Failed to deserialize BotGuard challange: 'InterpreterJs.PrivateDoNotAccessOrElseSafeScriptWrappedValue' is null."),
                privateDoNotAccessOrElseTrustedResourceUrlWrappedValue: challengeData[2]?.AsArray().FindFirstString()));
    }


    /// <summary>
    /// The ID of the JSPB message.
    /// </summary>
    public string MessageId { get; set; } = messageId;

    /// <summary>
    /// The hash of the script. Useful if you want to fetch the challenge script again at a later time.
    /// </summary>
    public string InterpreterHash { get; set; } = interpreterHash;

    /// <summary>
    /// The challenge program.
    /// </summary>
    public string Program { get; set; } = program;

    /// <summary>
    /// The name of the VM in the global scope.
    /// </summary>
    public string GlobalName { get; set; } = globalName;

    /// <summary>
    /// The client experiments state blob.
    /// </summary>
    public string ClientExperimentsStateBlob { get; set; } = clientExperimentsStateBlob;

    /// <summary>
    /// The script associated with the challenge.
    /// </summary>
    public BotGuardInterpreterJs InterpreterJs { get; set; } = interpreterJs;
}