using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;

namespace Belp.CodeAnalysis.ManifestResourceGenerators.UnitTests;

internal class CSharpIncrementalSourceGeneratorVerifier<TSourceGenerator>
    where TSourceGenerator : IIncrementalGenerator, new()
{
    public class Test : CSharpSourceGeneratorTest<EmptySourceGeneratorProvider, XUnitVerifier>
    {
        public LanguageVersion LanguageVersion { get; init; } = LanguageVersion.CSharp10;

        /// <inheritdoc />
        protected override IEnumerable<ISourceGenerator> GetSourceGenerators()
        {
            return new TSourceGenerator().AsSourceGenerator().AsSingletonEnumerable();
        }

        /// <inheritdoc />
        protected override ParseOptions CreateParseOptions()
        {
            return ((CSharpParseOptions)base.CreateParseOptions()).WithLanguageVersion(LanguageVersion);
        }
    }
}
