namespace DotnetCliWrapper.Models;

/// <summary>
/// 
/// </summary>
/// <param name="FailedTests"></param>
/// <param name="StandardOutput"></param>
/// <param name="StandardError"></param>
public readonly record struct TestResponse(
    IReadOnlyCollection<FailedTest> FailedTests,
    string StandardOutput,
    string StandardError);