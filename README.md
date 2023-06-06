# DotnetCliWrapper

[![Nuget package](https://img.shields.io/nuget/vpre/DotnetCliWrapper)](https://www.nuget.org/packages/DotnetCliWrapper/)
[![dotnet](https://github.com/tryAGI/DotnetCliWrapper/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/tryAGI/DotnetCliWrapper/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/github/license/tryAGI/DotnetCliWrapper)](https://github.com/tryAGI/DotnetCliWrapper/blob/main/LICENSE)
[![Discord](https://img.shields.io/discord/1115206893015662663?label=Discord&logo=discord&logoColor=white&color=d82679)](https://discord.gg/Ca2xhfBf3v)

Allows you to simply run dotnet cli from C# and get parsed results

### Usage
```csharp
var response = await Dotnet.BuildAsync("path/to/folder/with/csproj/or/sln");
foreach(var diagnostuc in response.Diagnostics)
{
    Console.WriteLine(diagnostic);
}
```

## Support

Priority place for bugs: https://github.com/tryAGI/DotnetCliWrapper/issues  
Priority place for ideas and general questions: https://github.com/tryAGI/DotnetCliWrapper/discussions  
Discord: https://discord.gg/Ca2xhfBf3v  