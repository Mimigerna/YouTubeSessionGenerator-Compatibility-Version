using Microsoft.Extensions.Logging;

namespace YouTubeSessionGenerator.Tests;

public class Program
{
    [Test]
    public async Task MainAsync()
    {
        // Getting Started
        ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger logger = factory.CreateLogger<Program>();


    }
}