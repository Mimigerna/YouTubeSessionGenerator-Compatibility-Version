using YouTubeSessionGenerator.Js;
using YouTubeSessionGenerator.Js.Environments;

namespace YouTubeSessionGenerator.Tests;

public class YouTubeSessionGeneratorTests
{
    [Test]
    public void Should_generate_proof_of_origin_token()
    {
        // Arrange
        using IJsEnvironment environment = new NodeEnvironment();
        YouTubeSessionGenerator generator = new(new() { JsEnvironment = environment });

        // Act
        string? proofOfOriginToken = null;

        Assert.DoesNotThrowAsync(async () =>
        {
            proofOfOriginToken = await generator.CreateProofOfOriginTokenAsync();
        });

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(proofOfOriginToken, Is.Not.Null.Or.Empty);
        });

        // Output
        TestContext.Out.WriteLine("Proof Of Origin Token: {0}", proofOfOriginToken);
    }
}