# JsException
Represents an exception that occurs during the execution of JavaScript code within a JS environment.
- **Type:** Class
- **Namespace:** [YouTubeSessionGenerator.Js](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/)
- **Implements:**  [Exception](https://learn.microsoft.com/dotnet/api/system.exception), [ISerializable](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)
```cs
public class JsException : Exception, ISerializable
```


## Constructors
Creates a new instance of the [JsException](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/JsException.html) class with a specified error message.
```cs
public JsException(
  string message, 
  JsScript script)
```
| Parameter | Summary |
| --------- | ------- |
| [`string`](https://learn.microsoft.com/dotnet/api/system.string) message | The message returned by the JavaScript engine. |
| [`JsScript`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/JsScript.html) script | The original JavaScript script which caused the exception. |

Initializes a new instance of the [JsException](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/JsException.html) class with a specified error message and inner exception.
```cs
public JsException(
  string message, 
  Exception innerException, 
  JsScript script)
```
| Parameter | Summary |
| --------- | ------- |
| [`string`](https://learn.microsoft.com/dotnet/api/system.string) message | The message returned by the JavaScript engine. |
| [`Exception`](https://learn.microsoft.com/dotnet/api/system.exception) innerException | The exception that is the cause of this exception. |
| [`JsScript`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/JsScript.html) script | The original JavaScript script which caused the exception. |





## Properties

### Script
The original JavaScript script which caused the exception.
- **Type:** [JsScript](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/Js/JsScript.html)
- **Is Read Only:** `True`

### TargetSite
- **Type:** [MethodBase](https://learn.microsoft.com/dotnet/api/system.reflection.methodbase)
- **Is Read Only:** `True`

### Message
- **Type:** [string](https://learn.microsoft.com/dotnet/api/system.string)
- **Is Read Only:** `True`

### Data
- **Type:** [IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.idictionary)
- **Is Read Only:** `True`

### InnerException
- **Type:** [Exception](https://learn.microsoft.com/dotnet/api/system.exception)
- **Is Read Only:** `True`

### HelpLink
- **Type:** [string](https://learn.microsoft.com/dotnet/api/system.string)
- **Is Read Only:** `False`

### Source
- **Type:** [string](https://learn.microsoft.com/dotnet/api/system.string)
- **Is Read Only:** `False`

### HResult
- **Type:** [int](https://learn.microsoft.com/dotnet/api/system.int)
- **Is Read Only:** `False`

### StackTrace
- **Type:** [string](https://learn.microsoft.com/dotnet/api/system.string)
- **Is Read Only:** `True`
