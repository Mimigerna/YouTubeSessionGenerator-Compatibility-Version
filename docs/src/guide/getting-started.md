---
title: Getting Started
icon: fluent:lightbulb-16-filled
order: 3
---

This guide will help you get started with **YouTubeSessionGenerator** by walking you through the setup and usage of the library to generate a trusted session for the internal YouTube API (InnerTube).

::: note
If you haven't installed the library yet, head over to the [Installation page](installation.html) first.
:::


## 1. Create an instance
To start generating session tokens like **Visitor Data**, **Proof of Origin Tokens** or **Rollout Tokens**, you'll first need to initialize an instance of [`YouTubeSessionGenerator`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/YouTubeSessionGenerator.html) with a configuration:
```cs
using YouTubeSessionGenerator;

YouTubeSessionConfig config = new()
{
    JsEnvironment = myCustomJsEnvironment,  // Required when generating Proof of Origin Tokens
    HttpClient = myCustomHttpClient,        // Optional: Provide your own HttpClient
    Logger = myCustomLogger                 // Optional: Enable logging
};
YouTubeSessionGenerator generator = new(config);
```

::: danger
If you're passing a [`JsEnvironment`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/YouTubeSessionConfig.html#jsenvironment), you are **responsible** for disposing it! For example, the built-in [`NodeEnvironment`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/Environments/NodeEnvironment.html) spawns a subprocess that won't be closed until **disposed**.

Use a `using` statement or manually call `.Dispose()` in a `try/finally` block when done.
:::


## 2. Generate Session Tokens
Once we have an instance of [`YouTubeSessionGenerator`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/YouTubeSessionGenerator.html), we can start generating the session tokens:

#### Generate Visitor Data
```cs
string visitorData = await generator.CreateVisitorDataAsync();
```

#### Generate Proof of Origin Token
```cs
// Requires a JavaScript environment!
string poToken = await generator.CreateProofOfOriginTokenAsync(visitorData);
```

#### Generate Rollout Token
```cs
string rolloutToken = await generator.CreateRolloutTokenAsync();
```


## 3. Use the Tokens
Once you have the tokens, you can use them in your HTTP requests to YouTube's InnerTube API:
```json
{
  "context": {
    "client": {
      "visitorData": "<VISITOR_DATA>",
      "rolloutToken": "<ROLLOUT_TOKEN>",
      ...
    }
  },
  "serviceIntegrityDimensions": {
    "poToken": "<PROOF_OF_ORIGIN_TOKEN>"
  },
  ...
}
```
::: note
This structure is commonly used for requests to endpoints like `browse`, `player`, or `next`. Some fields may vary depending on the endpoint.
:::


## What's Next?
- Learn about all available config options in the [Configuration guide](configuration.html)
- Dive deeper into [how the tokens work](../guide/#session-tokens-explained)
- Explore the [library reference](/YouTubeSessionGenerator/reference/)