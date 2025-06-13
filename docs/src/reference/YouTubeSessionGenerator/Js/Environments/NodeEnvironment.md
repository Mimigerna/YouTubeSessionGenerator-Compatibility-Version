# NodeEnvironment
Represents an execution environment capable of running JavaScript code powered by a Node.js process.
- **Type:** Class
- **Namespace:** [YouTubeSessionGenerator.Js.Environments](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/Environments/)
- **Implements:**  [IJsEnvironment](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/IJsEnvironment.html), [IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)
```cs
public class NodeEnvironment : IJsEnvironment, IDisposable
```


## Constructors
Requires Node.js to be installed and available in the system PATH.
Only works on platforms which allow spawning external untime processes, such as Windows, Linux, and macOS.
```cs
public NodeEnvironment(
  string fileName)
```
| Parameter | Summary |
| --------- | ------- |
| [`string`](https://learn.microsoft.com/dotnet/api/system.string) fileName | The path to the Node.js executable. Use <c>"node"</c> to rely on the system's PATH. |



## Methods

### Dispose
Releases all resources used by the current instance of the [NodeEnvironment](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/Environments/NodeEnvironment.html) class and shuts down the Node.js process.
```cs
public Void Dispose()
```

### ExecuteAsync
Executes the specified JavaScript code asynchronously in the Node.js environment.
```cs
public Task<string> ExecuteAsync(
  JsScript script)
```
| Parameter | Summary |
| --------- | ------- |
| [`JsScript`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/JsScript.html) script | The [JsScript](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/JsScript.html) to execute. |



