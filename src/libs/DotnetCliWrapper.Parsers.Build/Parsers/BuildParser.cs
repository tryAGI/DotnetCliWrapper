using System.Text.RegularExpressions;
using DotnetCliWrapper.Models;

namespace DotnetCliWrapper.Parsers;

/// <summary>
/// 
/// </summary>
public static partial class BuildParser
{
    [GeneratedRegex(
        pattern: @"(?<filepath>.*)\((?<line>\d+),(?<column>\d+)\):\s(?<type>\w+)\s(?<id>[\w\d]+)?:\s(?<message>.*)(\s\[(?<projectpath>.*?)(::TargetFramework=(?<targetframework>.*))?\])",
        options: RegexOptions.IgnoreCase,
        cultureName: "en-US")]
    private static partial Regex DiagnosticRegex();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="output"></param>
    /// <returns></returns>
    public static BuildResponse Parse(string output)
    {
        var diagnostics = new List<Diagnostic>();

        var regex = DiagnosticRegex();
        foreach (Match match in regex.Matches(output))
        {
            var filePath = match.Groups["filepath"].Value;
            var line = match.Groups["line"].Value;
            var column = match.Groups["column"].Value;
            var type = match.Groups["type"].Value;
            var id = match.Groups["id"].Value;
            var message = match.Groups["message"].Value;
            var projectPath = match.Groups["projectpath"].Value;
            var targetFramework = match.Groups["targetframework"].Value;
            
            diagnostics.Add(new Diagnostic(
                FilePath: filePath,
                Line: int.TryParse(line, out var lineValue) ? lineValue : 0,
                Column: int.TryParse(column, out var columnValue) ? columnValue : 0,
                Severity: Enum.Parse<DiagnosticSeverity>(type, ignoreCase: true),
                Id: id,
                Message: message,
                ProjectPath: projectPath,
                TargetFramework: targetFramework,
                Content: match.Groups[0].Value));
        }
        
        return new BuildResponse(
            Diagnostics: diagnostics.Distinct().ToArray(),
            StandardOutput: output,
            StandardError: string.Empty);
    }
}