using YouTubeSessionGenerator.Js;
using YouTubeSessionGenerator.Js.Environments;

namespace YouTubeSessionGenerator.Tests.Js;

public class NodeEnvironmentTests
{
    [Test]
    public void Should_run_code()
    {
        // Arrange
        NodeEnvironment environment = new();
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
        NodeEnvironment environment = new();
        JsScript script = new("args[0] * 2 + args[1];", [ 21, 56 ]);
        JsScript script2 = new("args[1] * 2 + args[0];", [ 21, 56 ]);

        // Act
        string? response1 = null;
        string? response2 = null;

        Assert.DoesNotThrowAsync(async () =>
        {
            response1 = await environment.ExecuteAsync(script);
            response2 = await environment.ExecuteAsync(script2);
        });

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(response1, Is.EqualTo("98"));
            Assert.That(response2, Is.EqualTo("133"));
        });
    }

    [Test]
    public void Should_keep_context()
    {
        // Arrange
        NodeEnvironment environment = new();
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
    public void Should_have_dom()
    {
        // Arrange
        NodeEnvironment environment = new();
        JsScript script = new("""
            document.body.innerHTML = '<div class="container"></div>';

            const container = document.querySelector('.container');
            const button = document.createElement('button');

            container.appendChild(button);

            document.body.innerHTML;
            """);

        // Act
        string? response = null;

        Assert.DoesNotThrowAsync(async () =>
        {
            response = await environment.ExecuteAsync(script);
        });

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(response, Is.EqualTo("<div class=\"container\"><button></button></div>"));
        });
    }

    [Test]
    public void Should_throw_custom_error()
    {
        // Arrange
        NodeEnvironment environment = new();
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
        NodeEnvironment environment = new();
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
        NodeEnvironment environment = new();

        environment.Dispose();

        Assert.That(() => environment, Throws.Nothing);
    }
}