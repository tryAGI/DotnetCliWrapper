using System.Text.RegularExpressions;
using DotnetCliWrapper.Models;

namespace DotnetCliWrapper.Parsers;

/// <summary>
/// 
/// </summary>
public static partial class TestParser
{
    [GeneratedRegex(
        pattern: @"Failed (?<testname>[\w\d]+) \[(?<executiontime>.+?) ms\]\s*Error Message:\s*(?<errormessage>.+?)Stack Trace:(?<stacktrace>.*?)(?=Failed|\Z)",
        options: RegexOptions.Singleline | RegexOptions.Multiline,
        cultureName: "en-US")]
    private static partial Regex FailedTestsRegex();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="output"></param>
    /// <returns></returns>
    public static TestResponse Parse(string output)
    {
        var failedTests = new List<FailedTest>();

        var regex = FailedTestsRegex();
        foreach (Match match in regex.Matches(output))
        {
            var testName = match.Groups["testname"].Value;
            var executionTime = match.Groups["executiontime"].Value;
            var errorMessage = match.Groups["errormessage"].Value;
            var stackTrace = match.Groups["stacktrace"].Value;
            
            failedTests.Add(new FailedTest(
                Name: testName,
                ExecutionTime: executionTime,
                ErrorMessage: errorMessage,
                StackTrace: stackTrace,
                Content: match.Groups[0].Value));
        }
        
        return new TestResponse(
            FailedTests: failedTests.ToArray(),
            StandardOutput: output,
            StandardError: string.Empty);
    }
}