# YouTubeSessionConfig
Contains configuration options for the YouTube session creator.
- **Type:** Class
- **Namespace:** [YouTubeSessionGenerator](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/)
```cs
public class YouTubeSessionConfig
```


## Constructors
Initializes a new instance of the [YouTubeSessionConfig](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/YouTubeSessionConfig.html) class.
```cs
public YouTubeSessionConfig()
```




## Properties

### JsEnvironment
The JavaScript environment used to execute scripts for generating PoTokens.
- **Type:** [IJsEnvironment](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/IJsEnvironment.html)
- **Is Read Only:** `False`

### HttpClient
The HTTP client used to send requests to YouTube.
- **Type:** [HttpClient](https://learn.microsoft.com/dotnet/api/system.net.http.httpclient)
- **Is Read Only:** `False`

### Logger
The logger used to provide progress and error messages.
- **Type:** [ILogger](https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger)
- **Is Read Only:** `False`
