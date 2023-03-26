using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;

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

    [Fact]
    public void Expect_AssemblyVersion_Not_Set()
    {
        BuildResult result = RequestBuild(Path.Combine(Resources.Path, "AssemblyVersionTests", "Test.DisabledGeneration", "Test.DisabledGeneration.csproj"));

        ProjectPropertyInstance p_AssemblyVersion = result.ProjectStateAfterBuild.GetProperty("AssemblyVersion");
        p_AssemblyVersion.Should().NotBeNull();
        p_AssemblyVersion.EvaluatedValue.Should().Be("5.3.1.4");
    }

    private class TestLogger_AssemblyVersion_Defined : XUnitMSBuildLoggerAdapter
    {
        public bool ExpectedErrorsRaised { get; private set; }

        public bool OtherErrorsRaised { get; private set; }

        public TestLogger_AssemblyVersion_Defined(ITestOutputHelper output) : base(output)
        {
        }

        public override void Initialize(IEventSource eventSource)
        {
            base.Initialize(eventSource);
            eventSource.ErrorRaised += (sender, e) =>
            {
                if (e.Code == "ASV4001" && e.Message == "AssemblyVersion is already defined. Please uninstall or disable(set $(Autoasmver_Disable) to true) the package to manually define AssemblyVersion.")
                {
                    ExpectedErrorsRaised = true;
                }
                else
                {
                    OtherErrorsRaised = true;
                }
            };
        }
    }

    [Fact]
    public void Expect_Error_AssemblyVersion_Defined()
    {
        var logger = new TestLogger_AssemblyVersion_Defined(Logger);
        _ = BuildManager.DefaultBuildManager.Build(
            new BuildParametersWithDefaults(logger),
            new BuildRequestData(
                Path.Combine(Resources.Path, "AssemblyVersionTests", "Test.AssemblyVersionDefined", "Test.AssemblyVersionDefined.csproj"),
                new Dictionary<string, string>(),
                null,
                new string[] { "Restore", "Build" }, null,
                BuildRequestDataFlags.None
            )
        );

        logger.OtherErrorsRaised.Should().BeFalse();
        logger.ExpectedErrorsRaised.Should().BeTrue();
    }
}
