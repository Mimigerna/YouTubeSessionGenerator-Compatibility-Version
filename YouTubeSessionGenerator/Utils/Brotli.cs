using System.IO.Compression;
using System.Text;

namespace YouTubeSessionGenerator.Utils;

/// <summary>
/// Contains methods to compress and decompress strings using Brotli compression.
/// </summary>
internal static class Brotli
{
    /// <summary>
    /// Compresses a string using Brotli compression.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The result as a Base64 encoded string.</returns>
    public static string Compress(
        string input)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);

        using MemoryStream outputStream = new();
        using (BrotliStream brotliStream = new(outputStream, CompressionLevel.SmallestSize))
            brotliStream.Write(inputBytes, 0, inputBytes.Length);

        byte[] compressedBytes = outputStream.ToArray();
        return Convert.ToBase64String(compressedBytes);
    }

    /// <summary>
    /// Decompresses a Brotli compressed string.
    /// </summary>
    /// <param name="input">The input stromg as a Base64 encoded string.</param>
    /// <returns>The result.</returns>
    public static string Decompress(
        string input)
    {
        byte[] inputBytes = Convert.FromBase64String(input);
        using MemoryStream inputStream = new(inputBytes);

        using BrotliStream brotliStream = new(inputStream, CompressionMode.Decompress);
        using MemoryStream outputStream = new();
        brotliStream.CopyTo(outputStream);

        byte[] decompressedBytes = outputStream.ToArray();
        return Encoding.UTF8.GetString(decompressedBytes);
    }
}