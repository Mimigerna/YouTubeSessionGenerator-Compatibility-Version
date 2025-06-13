using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Nodes;
using YouTubeSessionGenerator.BotGuard;

namespace YouTubeSessionGenerator.Utils;

/// <summary>
/// Contains helper extension methods.
/// </summary>
internal static class Extensions
{
    [DoesNotReturn]
    public static void LogErrorAndThrow(
        this ILogger? logger,
        Exception exception,
        string message)
    {
        logger?.LogError(exception, message);
        throw exception;
    }


    public static string? FindFirstString(
        this JsonArray? rawArray)
    {
        if (rawArray is null)
            return null;

        foreach (JsonNode? element in rawArray)
            if (element?.GetValue<string>() is string str)
                return str;

        return null;
    }


    public static byte[] ToBytesFromBase64(
        this string base64)
    {
        string base64Mod = base64
            .Replace('-', '+')
            .Replace('_', '/');

        switch (base64Mod.Length % 4)
        {
            case 2:
                base64Mod += "==";
                break;
            case 3:
                base64Mod += "=";
                break;
        }

        return Convert.FromBase64String(base64Mod);
    }

    public static string ToBase64FromBytes(
        this byte[] bytes,
        bool base64url = false)
    {
        string base64 = Convert.ToBase64String(bytes);

        if (base64url)
            base64 = base64
                .Replace('+', '-')
                .Replace('/', '_')
                .TrimEnd('=');

        return base64;
    }


    public static Dictionary<string, object?> Flatten(
        this BotGuardContentBinding contentBinding)
    {
        Dictionary<string, object?> result = new()
        {
            ["c"] = contentBinding.C,
            ["e"] = contentBinding.E,
            ["encryptedVideoId"] = contentBinding.EncryptedVideoId,
            ["externalChannelId"] = contentBinding.ExternalChannelId,
            ["commentId"] = contentBinding.CommentId,
            ["atr_challenge"] = contentBinding.AtrChallenge
        };

        if (contentBinding.AdditionalProperties is not null)
            foreach (KeyValuePair<string, object> property in contentBinding.AdditionalProperties)
                result[property.Key] = property.Value;

        return result;
    }
}