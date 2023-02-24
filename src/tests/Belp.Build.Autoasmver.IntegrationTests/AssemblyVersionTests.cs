namespace Belp.Build.Autoasmver.IntegrationTests;

public class AssemblyVersionTests : MSBuildTest
{
    public AssemblyVersionTests(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public void Expect_AssemblyVersion_Set()
    {
        BuildResult result = RequestBuild(Path.Combine(Resources.Path, "AssemblyVersionTests", "Test.Project1", "Test.Project1.csproj"));

        ProjectPropertyInstance p_AssemblyVersion = result.ProjectStateAfterBuild.GetProperty("AssemblyVersion");
        p_AssemblyVersion.Should().NotBeNull();
        p_AssemblyVersion.EvaluatedValue.Should().Be("5.0.0.0");
    }
}
