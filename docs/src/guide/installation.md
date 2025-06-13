---
title: Installation
icon: icon-park-solid:install
order: 2
---

YouTubeSessionGenerator is available as a [NuGet package](https://www.nuget.org/packages/YouTubeSessionGenerator) and can be easily added to your .NET project.

::: code-tabs

@tab .NET CLI

```bash
dotnet add package YouTubeSessionGenerator --version XXX.XXX.XXX
```

@tab Package Manager

```ps
NuGet\Install-Package YouTubeSessionGenerator -Version XXX.XXX.XXX
```

@tab PackageReference

```xml
<PackageReference Include="YouTubeSessionGenerator" Version="XXX.XXX.XXX" />
```

:::


## Prerequisites

- .NET 9.0 or later
- **Proof of Origin Token** generation requires a JavaScript environment. The built-in `NodeEnvironment` supports Windows, Linux & macOS, but you can plug in your own if needed. [Learn more here](configuration.html).


## Optional: Build from Source
If you want to build the library from source instead of using the precompiled binaries or NuGet package, follow these steps:

#### 1. Clone the repository
```bash
git clone https://github.com/IcySnex/YouTubeSessionGenerator.git
cd YouTubeSessionGenerator
```

#### 2. Restore dependencies
```bash
dotnet restore
```

#### 3. Build the library
```bash
dotnet build -c Release
```

#### 4. Reference the built DLL
You can reference the built DLL(s) from the bin/Release folder in your projects.