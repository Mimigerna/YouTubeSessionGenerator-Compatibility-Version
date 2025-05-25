using YouTubeSessionGenerator.Js;
using YouTubeSessionGenerator.Js.Environments;

namespace YouTubeSessionGenerator.Tests.Js;

public class NodeEnvironmentTests
{
    [Test]
    public void Should_run_code()
    {
        // Arrange
        IJsEnvironment environment = new NodeEnvironment();
        JsScript script = new("6 + 4;");

        // Act
        string? response = null;

        Assert.DoesNotThrowAsync(async () =>
        {
            response = await environment.ExecuteAsync(script);
        });

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(response, Is.EqualTo("10"));
        });
    }
    
    [Test]
    public void Should_have_context()
    {
        // Arrange
        IJsEnvironment environment = new NodeEnvironment();
        JsScript script = new("args[0] * 2 + args[1];", [ 21, 56 ]);

        // Act
        string? response = null;

        Assert.DoesNotThrowAsync(async () =>
        {
            response = await environment.ExecuteAsync(script);
        });

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(response, Is.EqualTo("98"));
        });
    }

    [Test]
    public void Should_keep_context()
    {
        // Arrange
        IJsEnvironment environment = new NodeEnvironment();
        JsScript firstScript = new("var someProperty = \"hii\";");
        JsScript secondScript = new("someProperty += \" -haii back\";");

        // Act
        string? response = null;

        Assert.DoesNotThrowAsync(async () =>
        {
            await environment.ExecuteAsync(firstScript);
            response = await environment.ExecuteAsync(secondScript);
        });

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(response, Is.EqualTo("hii -haii back"));
        });
    }

    [Test]
    public void Should_throw_custom_error()
    {
        // Arrange
        IJsEnvironment environment = new NodeEnvironment();
        JsScript script = new("throw new Error(\"BOOM\");");

        // Act
        JsException ex = Assert.ThrowsAsync<JsException>(async () =>
        {
            await environment.ExecuteAsync(script);
        });

        // Assert
        Assert.That(ex.Message, Does.Contain("BOOM"));
    }

    [Test]
    public void Should_throw_on_invalid_js()
    {
        // Arrange
        IJsEnvironment environment = new NodeEnvironment();
        JsScript script = new("var = = 5");

        // Act
        JsException ex = Assert.ThrowsAsync<JsException>(async () =>
        {
            await environment.ExecuteAsync(script);
        });

        // Assert
        Assert.That(ex.Message, Does.Contain("Unexpected token"));
    }

    [Test]
    public void Should_terminate_process_on_dispose()
    {
        IJsEnvironment environment = new NodeEnvironment();

        environment.Dispose();

        Assert.That(() => environment, Throws.Nothing);
    }
}