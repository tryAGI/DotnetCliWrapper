using CliWrap;
using CliWrap.Buffered;
using DotnetCliWrapper.Models;
using DotnetCliWrapper.Parsers;

namespace DotnetCliWrapper;

/// <summary>
/// 
/// </summary>
public static class Dotnet
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workingDirectory"></param>
    /// <param name="cancellationToken"></param>
    public static async Task<BuildResponse> BuildAsync(
        string workingDirectory,
        CancellationToken cancellationToken = default)
    {
        var result = await Cli.Wrap("dotnet")
            .WithArguments(new[] {"build"})
            .WithWorkingDirectory(workingDirectory)
            .WithValidation(CommandResultValidation.None)
            .ExecuteBufferedAsync(cancellationToken);

        return BuildParser.Parse(result.StandardOutput);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="workingDirectory"></param>
    /// <param name="cancellationToken"></param>
    public static async Task<TestResponse> TestAsync(
        string workingDirectory,
        CancellationToken cancellationToken = default)
    {
        var result = await Cli.Wrap("dotnet")
            .WithArguments(new[] {"test"})
            .WithWorkingDirectory(workingDirectory)
            .WithValidation(CommandResultValidation.None)
            .ExecuteBufferedAsync(cancellationToken);

        return TestParser.Parse(result.StandardOutput);
    }
}