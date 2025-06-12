---
title: Configuration
icon: weui:setting-filled
order: 4
---

The `YouTubeSessionGenerator` class can be customized using the `YouTubeSessionConfig` object passed to its constructor. This page outlines all available options and how to use them effectively.

```cs
YouTubeSessionGenerator generator = new(new YouTubeSessionConfig()
{
    JsEnvironment = new NodeEnvironment(), // or any custom IJsEnvironment
    HttpClient = new HttpClient(),
    Logger = logger
});
```


## JsEnvironment
Generating a [Proof of Origin Token](../guide/#proof-of-origin-token) and bypassing YouTube's anti-bot system [BotGuard](https://botguard.net/en/home) requires executing custom JavaScript scripts in an environment which supports the DOM.
- Type: [`IJsEnvironment`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/IJsEnvironment.html)
- Required for [`CreateProofOfOriginTokenAsync`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/YouTubeSessionGenerator.html#createproofoforigintokenasync)
- If omitted, methods like [`CreateVisitorDataAsync`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/YouTubeSessionGenerator.html#createvisitordataasync) and [`CreateRolloutTokenAsync`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/YouTubeSessionGenerator.html#createrollouttokenasync) will still work

#### Built-in
The built-in JavaScript environment uses [node.js](https://nodejs.org) under the hood. This supports Windows, Linux and macOS.

::: details Why not use a portable Js-Interpreter?
You may ask why not just use a cross platform fully .NET JavaScript interpreter like [Jint](https://github.com/sebastienros/jint), but instead rely on the entire bulky node environment?

Well first of all, passing the anti-bot system requires a *real* browser environment - okay, no worries lets simulate it: There are plenty of libraries like [happy-dom](https://github.com/capricorn86/happy-dom) or [jsdom](https://github.com/jsdom/jsdom) which can be "ported" to Jint. But even after getting happy dom to sucessfully run, for some reason the BotGuard system still generated invalid tokens.

After spending **way** too many hours trying to get this to work, I finally gave up and just use a [node.js](https://nodejs.org) subprocess - still better than an entrie headless browser. But as this project is open-source I would love to see a pull request achieving my goal and proving me wrong.
:::

#### Custom
For other platforms you will have to implement own logic to execute the neccesary scripts e.g. using a headless browser or a JavaScript environment in the cloud. To do this you will have to implement the [`IJsEnvironment`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/IJsEnvironment.html) interface:
```cs
using YouTubeSessionGenerator.Js;

public class CustomJsEnvironment : IJsEnvironment
{
    Task<string?> ExecuteAsync(JsScript script);
    {
        string code = script.Code;
        object?[] args = script.Args;

        // Execute code with args..
    }
}
```
Make sure your custom JavaScript environment has access to a DOM and passes all 