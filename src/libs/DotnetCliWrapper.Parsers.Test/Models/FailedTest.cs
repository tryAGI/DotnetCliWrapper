namespace DotnetCliWrapper.Models;

/// <summary>
/// 
/// </summary>
/// <param name="Name"></param>
/// <param name="ExecutionTime"></param>
/// <param name="ErrorMessage"></param>
/// <param name="StackTrace"></param>
/// <param name="Content"></param>
public readonly record struct FailedTest(
    string Name,
    string ExecutionTime,
    string ErrorMessage,
    string StackTrace,
    string Content)
{
    /// <inheritdoc />
    public override string ToString()
    {
        return $"{Name}: {ErrorMessage}";
    }
}