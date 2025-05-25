using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Nodes;

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
}