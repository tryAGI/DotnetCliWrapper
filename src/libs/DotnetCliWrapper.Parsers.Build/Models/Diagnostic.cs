namespace DotnetCliWrapper.Models;

/// <summary>
/// 
/// </summary>
/// <param name="FilePath"></param>
/// <param name="Line"></param>
/// <param name="Column"></param>
/// <param name="Severity"></param>
/// <param name="Id"></param>
/// <param name="Message"></param>
/// <param name="ProjectPath"></param>
/// <param name="TargetFramework"></param>
/// <param name="Content"></param>
public readonly record struct Diagnostic(
    string FilePath,
    int Line,
    int Column,
    DiagnosticSeverity Severity,
    string Id,
    string Message,
    string ProjectPath,
    string TargetFramework,
    string Content)
{
    /// <inheritdoc />
    public override string ToString()
    {
        return Message;
    }
}