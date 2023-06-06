namespace DotnetCliWrapper.Models;

/// <summary>
/// 
/// </summary>
/// <param name="Diagnostics"></param>
/// <param name="StandardOutput"></param>
/// <param name="StandardError"></param>
public readonly record struct BuildResponse(
    IReadOnlyCollection<Diagnostic> Diagnostics,
    string StandardOutput,
    string StandardError);