using Microsoft.CodeAnalysis.Testing;
using SGTest = Belp.CodeAnalysis.ManifestResourceGenerators.UnitTests.CSharpIncrementalSourceGeneratorVerifier<Belp.CodeAnalysis.ManifestResourceGenerators.ManifestResourcesGenerator>.Test;

namespace Belp.CodeAnalysis.ManifestResourceGenerators.UnitTests.ManifestResourcesGenerator;

public class DiagnosticsTest
{
    private class EmptyProjectNameTest : SGTest
    {
        protected override string DefaultTestProjectName => "";
    }

    [Fact]
    public async Task AssemblyName_eq_null_Errors()
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

        await test.RunAsync();
    }
}
