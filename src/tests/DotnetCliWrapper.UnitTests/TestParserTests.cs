using DotnetCliWrapper.Parsers;

namespace DotnetCliWrapper.IntegrationTests;

[TestClass]
public class TestParserTests
{
    [TestMethod]
    public void ParseDotnetTestTryAgiLegacyApp()
    {
        Parse(
            output: H.Resources.dotnet_test_tryagi_legacyapp_txt.AsString(),
            expectedFailedTestsCount: 2);
    }
    
    [TestMethod]
    public void ParseDotnetTestTryAgiRefactoringTest()
    {
        Parse(
            output: H.Resources.dotnet_test_tryagi_refactoringtest_txt.AsString(),
            expectedFailedTestsCount: 0);
    }
    
    [TestMethod]
    public void ParseDotnetTestHavenDvHSocketIo()
    {
        Parse(
            output: H.Resources.dotnet_test_havendv_hsocketio_txt.AsString(),
            expectedFailedTestsCount: 0);
    }
    
    [TestMethod]
    public void ParseDotnetTestHavenDvHNotifyIcon()
    {
        Parse(
            output: H.Resources.dotnet_test_havendv_hnotifyicon_txt.AsString(),
            expectedFailedTestsCount: 8);
    }
    
    private static void Parse(
        string output,
        int expectedFailedTestsCount)
    {
        var response = TestParser.Parse(output);

        response.FailedTests.Should().HaveCount(expectedFailedTestsCount);
    }
}