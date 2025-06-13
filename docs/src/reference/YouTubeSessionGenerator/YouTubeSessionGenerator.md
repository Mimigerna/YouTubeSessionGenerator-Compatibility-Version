# YouTubeSessionGenerator
Contains methods to generate valid trusted sessions for YouTube including Visitor Data, Proof of Origin Tokens &amp; Rollout Tokens.
- **Type:** Class
- **Namespace:** [YouTubeSessionGenerator](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/)
```cs
public class YouTubeSessionGenerator
```


## Constructors
Initializes a new instance of the [YouTubeSessionGenerator](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/YouTubeSessionGenerator.html) class.
```cs
public YouTubeSessionGenerator(
  YouTubeSessionConfig config)
```
| Parameter | Summary |
| --------- | ------- |
| [`YouTubeSessionConfig`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/YouTubeSessionConfig.html) config | The configuration for this YouTube session generator |



## Methods

### CreateVisitorDataAsync
Generates Visitor Data for a YouTube session.
```cs
public Task<string> CreateVisitorDataAsync(
  CancellationToken cancellationToken)
```
| Parameter | Summary |
| --------- | ------- |
| *(optional)* [`CancellationToken`](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) cancellationToken | The token to cancel this task. |

### CreateRolloutTokenAsync
Generates rollout token for a YouTube session.
```cs
public Task<string> CreateRolloutTokenAsync(
  CancellationToken cancellationToken)
```
| Parameter | Summary |
| --------- | ------- |
| *(optional)* [`CancellationToken`](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) cancellationToken | The token to cancel this task. |

### CreateProofOfOriginTokenAsync
Generates a Proof of Origin Token (PoToken) for a YouTube session.
```cs
public Task<string> CreateProofOfOriginTokenAsync(
  string visitorData, 
  BotGuardContentBinding contentBinding, 
  CancellationToken cancellationToken)
```
| Parameter | Summary |
| --------- | ------- |
| [`string`](https://learn.microsoft.com/dotnet/api/system.string) visitorData | The Visitor Data connected to this proof of origin token. |
| *(optional)* [`BotGuardContentBinding`](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/BotGuard/BotGuardContentBinding.html) contentBinding | The content to which the Proof of Origin token is bound. |
| *(optional)* [`CancellationToken`](https://learn.microsoft.com/dotnet/api/system.threading.cancellationtoken) cancellationToken | The token to cancel this task. |



## Properties

### Config
The configuration for this YouTube session generator.
- **Type:** [YouTubeSessionConfig](/YouTubeSessionGenerator/reference/YouTubeSessionGenerator/YouTubeSessionConfig.html)
- **Is Read Only:** `True`
