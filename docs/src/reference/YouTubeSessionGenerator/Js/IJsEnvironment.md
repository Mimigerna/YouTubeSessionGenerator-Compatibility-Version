# IJsEnvironment
Represents an execution environment capable of running JavaScript code.
- **Type:** Interface
- **Namespace:** [YouTubeSessionGenerator.Js](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/)
- **Implements:**  [IDisposable](https://learn.microsoft.com/dotnet/api/system.idisposable)
```cs
public interface IJsEnvironment : IDisposable
```


## Methods

### ExecuteAsync
Executes the specified JavaScript script asynchronously within the environment.
```cs
public abstract Task<string> ExecuteAsync(
  JsScript script)
```
| Parameter | Summary |
| --------- | ------- |
| [`JsScript`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/JsScript.html) script | The [JsScript](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/JsScript.html) to execute. |



