using Microsoft.CodeAnalysis.Testing;
using SGTest = Belp.CodeAnalysis.ManifestResourceGenerators.UnitTests.CSharpIncrementalSourceGeneratorVerifier<Belp.CodeAnalysis.ManifestResourceGenerators.ManifestResourcesGenerator>.Test;

namespace Belp.CodeAnalysis.ManifestResourceGenerators.UnitTests;

public partial class ManifestResourcesGenerator
{
    public partial class DiagnosticsTest
    {
        private class EmptyProjectNameTest : SGTest
        {
            protected override string DefaultTestProjectName => "";
        }

        [Fact]
        public Task When_AssemblyName_eq_nullX2C_then_expect_CS8203_and_MRG4001()
        {
            var test = new EmptyProjectNameTest
            {
                ReferenceAssemblies = ReferenceAssemblies.NetStandard.NetStandard20,

                ExpectedDiagnostics =
            {
                DiagnosticResult.CompilerError("CS8203"),
                new DiagnosticResult(DiagnosticDescriptors.SourceGenerators.MRG4001),
            },
            };

            return test.RunAsync();
        }
    }
}
