using YouTubeSessionGenerator.Utils;

namespace YouTubeSessionGenerator.Tests;

public class BrotliTests
{
    [Test]
    public void Should_compress_using_brotli()
    {
        // Arrange
        string input = "This is a test string to compress using Brotli compression.";

        // Act
        string? result = null;

        Assert.DoesNotThrow(() =>
        {
            result = Brotli.Compress(input);
        });

        // Assert
        Assert.That(result, Is.EqualTo("GzoAcBypU587dC0U9ianQOjSJY0NNuDAoZeURhw24JgTCTBdbr2oSLmS7LiONZ97EAI="));

        // Output
        TestContext.Out.WriteLine("Result: {0}", result);
    }
    

    [Test]
    public void Should_decompress_using_brotli()
    {
        // Arrange
        string input = "GzoAcBypU587dC0U9ianQOjSJY0NNuDAoZeURhw24JgTCTBdbr2oSLmS7LiONZ97EAI=";

        // Act
        string? result = null;

        Assert.DoesNotThrow(() =>
        {
            result = Brotli.Decompress(input);
        });

        // Assert
        Assert.That(result, Is.EqualTo("This is a test string to compress using Brotli compression."));

        // Output
        TestContext.Out.WriteLine("Result: {0}", result);
    }

}