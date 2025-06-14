# YouTubeSessionGenerator
YouTubeSessionGenerator is a .NET library which allows you to generate valid trusted sessions for the internal YouTube API (InnerTube) including Visitor Data, Proof of Origin Tokens (PoTokens) & Rollout Tokens. Some of these parameters may be required to access certain parts of the InnerTube API.

This library is especially useful for services, automation tools, or projects that require valid authentication for YouTube communication - without the overhead of a full browser environment.

---

## Features
- **Trusted Sessions**: Generate sessions that pass YouTube’s anti-bot checks - unlock access to protected endpoints
- **Easy to Use**: Just a few lines of code required - no need to worry about the low-level details
- **Configurable**: Built for .NET with flexible config & pluggable JS environment support - no browser needed


## Getting Started
```cs
using YouTubeSessionGenerator;
using YouTubeSessionGenerator.Js.Environments;

using NodeEnvironment myCustomJsEnvironment = new(); // Make sure this gets dispoed!

YouTubeSessionConfig config = new()
{
    JsEnvironment = myCustomJsEnvironment,  // Required when generating Proof of Origin Tokens
    HttpClient = myCustomHttpClient,        // Optional: Provide your own HttpClient
    Logger = myCustomLogger                 // Optional: Enable logging
};
YouTubeSessionGenerator generator = new(config);

string visitorData = await generator.CreateVisitorDataAsync();
string poToken = await generator.CreateProofOfOriginTokenAsync(visitorData);
string rolloutToken = await generator.CreateRolloutTokenAsync();
```
To learn more, visit the full [Getting Started](https://icysnex.github.io/YouTubeSessionGenerator/guide/getting-started.html) & [Configuration](https://icysnex.github.io/YouTubeSessionGenerator/guide/configuration.html) Guide.


## How It Works
- **Visitor Data**: Session-level identity token
- **Proof of Origin Token**: BotGuard-validated, JS-signed token
- **Rollout Token**: Determines feature flags and experiments per session

Fore more details, see [here](https://icysnex.github.io/YouTubeSessionGenerator/guide/).


## Credits
This library was made possible thanks to the incredible reverse-engineering work and research by the open-source community, especially those who uncovered and shared insights into YouTube’s internal APIs.

Special thanks to the following projects and individuals:
- [LuanRT/BgUtils](https://github.com/LuanRT/BgUtils) - for their extensive description of how PoToken are generated.
- [LuanRT/YouTube.js](https://github.com/LuanRT/YouTube.js) - for their detailed understanding of the InnerTube API.
- [yt-dlp](https://github.com/yt-dlp/yt-dlp/wiki/PO-Token-Guide) - for their research of when and where PoTokens are required.
- [Hao Kuang](https://kuangbyte.medium.com/peeking-behind-the-curtain-decoding-youtubes-api-design-through-network-traffic-e3a68463df05) - for their detailed explanation of YouTube's internal API design.