# BotGuardException
Represents an exception that occurs during the execution of BotGuard related operations.
- **Type:** Class
- **Namespace:** [YouTubeSessionGenerator.BotGuard](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/BotGuard/)
- **Implements:**  [Exception](https://learn.microsoft.com/dotnet/api/system.exception), [ISerializable](https://learn.microsoft.com/dotnet/api/system.runtime.serialization.iserializable)
```cs
public class BotGuardException : Exception, ISerializable
```


## Constructors
Initializes a new instance of the [BotGuardException](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/BotGuard/BotGuardException.html) class.
```cs
public BotGuardException()
```
Initializes a new instance of the [BotGuardException](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/BotGuard/BotGuardException.html) class.
```cs
public BotGuardException(
  string message)
```
| Parameter | Summary |
| --------- | ------- |
| `string` message | The message that describes the error. |

Initializes a new instance of the [BotGuardException](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/BotGuard/BotGuardException.html) class.
```cs
public BotGuardException(
  string message, 
  Exception innerException)
```
| Parameter | Summary |
| --------- | ------- |
| `string` message | The error message that explains the reason for the exception. |
| `Exception` innerException | The exception that is the cause of the current exception. |





## Properties

### TargetSite
- **Type:** [System.Reflection.MethodBase](https://learn.microsoft.com/dotnet/api/system.reflection.methodbase)
- **Is Read Only:** `True`

### Message
- **Type:** [System.String](https://learn.microsoft.com/dotnet/api/system.string)
- **Is Read Only:** `True`

### Data
- **Type:** [System.Collections.IDictionary](https://learn.microsoft.com/dotnet/api/system.collections.idictionary)
- **Is Read Only:** `True`

### InnerException
- **Type:** [System.Exception](https://learn.microsoft.com/dotnet/api/system.exception)
- **Is Read Only:** `True`

### HelpLink
- **Type:** [System.String](https://learn.microsoft.com/dotnet/api/system.string)
- **Is Read Only:** `False`

### Source
- **Type:** [System.String](https://learn.microsoft.com/dotnet/api/system.string)
- **Is Read Only:** `False`

### HResult
- **Type:** [System.Int32](https://learn.microsoft.com/dotnet/api/system.int)
- **Is Read Only:** `False`

### StackTrace
- **Type:** [System.String](https://learn.microsoft.com/dotnet/api/system.string)
- **Is Read Only:** `True`
