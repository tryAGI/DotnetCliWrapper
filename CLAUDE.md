# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

.NET wrapper library for the `dotnet` CLI that executes commands programmatically from C# and returns parsed, structured results. Published as [DotnetCliWrapper](https://www.nuget.org/packages/DotnetCliWrapper/) on NuGet.

## Build Commands

```bash
# Build the solution
dotnet build DotnetCliWrapper.sln

# Build for release
dotnet build DotnetCliWrapper.sln -c Release

# Run unit tests
dotnet test src/tests/DotnetCliWrapper.UnitTests/DotnetCliWrapper.UnitTests.csproj

# Run all tests
dotnet test DotnetCliWrapper.sln
```

## Architecture

### Project Layout

| Project | Purpose |
|---------|---------|
| `src/libs/DotnetCliWrapper/` | Main library -- `Dotnet` static class with `BuildAsync()`, `TestAsync()` methods |
| `src/libs/DotnetCliWrapper.Parsers.Build/` | Parser for `dotnet build` output (diagnostics, errors, warnings) |
| `src/libs/DotnetCliWrapper.Parsers.Test/` | Parser for `dotnet test` output (test results) |
| `src/libs/Providers/LangChain.Providers.Abstractions/` | LangChain provider abstractions (bundled dependency) |
| `src/libs/Providers/LangChain.Providers.OpenAI/` | OpenAI LangChain provider (bundled dependency) |
| `src/tests/DotnetCliWrapper.UnitTests/` | Unit tests |

### How It Works

1. `Dotnet.BuildAsync(workingDirectory)` executes `dotnet build` via [CliWrap](https://github.com/Tyrrrz/CliWrap)
2. The buffered stdout is passed to `BuildParser.Parse()` which extracts structured diagnostics
3. `Dotnet.TestAsync(workingDirectory)` does the same for `dotnet test` via `TestParser.Parse()`
4. Results are returned as `BuildResponse` / `TestResponse` model objects

### Build Configuration

- **Target:** `net8.0`
- **Key dependency:** [CliWrap](https://github.com/Tyrrrz/CliWrap) for process execution
- **Central package management:** Uses `src/Directory.Packages.props`
- **Versioning:** Semantic versioning from git tags via MinVer

### CI/CD

- Uses shared workflows from `HavenDV/workflows` repo
- Dependabot updates NuGet packages (auto-merged)
