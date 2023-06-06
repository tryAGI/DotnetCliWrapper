using DotnetCliWrapper.Parsers;

namespace DotnetCliWrapper.IntegrationTests;

[TestClass]
public class BuildParserTests
{
    [TestMethod]
    public void ParseDotnetBuildTryAgiLegacyApp()
    {
        Parse(
            output: H.Resources.dotnet_build_tryagi_legacyapp_txt.AsString(),
            expectedDiagnosticCount: 5);
    }
    
    [TestMethod]
    public void ParseDotnetBuildTryAgiRefactoringTest()
    {
        Parse(
            output: H.Resources.dotnet_build_tryagi_refactoringtest_txt.AsString(),
            expectedDiagnosticCount: 3);
    }
    
    [TestMethod]
    public void ParseDotnetBuildHavenDvHSocketIo()
    {
        Parse(
            output: H.Resources.dotnet_build_havendv_hsocketio_txt.AsString(),
            expectedDiagnosticCount: 9);
    }
    
    [TestMethod]
    public void ParseDotnetBuildHavenDvHNotifyIcon()
    {
        Parse(
            output: H.Resources.dotnet_build_havendv_hnotifyicon_txt.AsString(),
            expectedDiagnosticCount: 96);
    }
    
    private static void Parse(
        string output,
        int expectedDiagnosticCount)
    {
        var response = BuildParser.Parse(output);

        response.Diagnostics.Should().HaveCount(expectedDiagnosticCount);
    }
}