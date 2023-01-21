using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;

namespace Belp.Tests;

/// <summary>
/// Provides a test for incremental source generators.
/// </summary>
/// <typeparam name="TSourceGenerator">The type of the incremental source generator.</typeparam>
public class CSharpIncrementalSourceGeneratorVerifier<TSourceGenerator>
    where TSourceGenerator : IIncrementalGenerator, new()
{
    /// <summary>
    /// Provides a test for incremental source generators.
    /// </summary>
    public class Test : CSharpSourceGeneratorTest<EmptySourceGeneratorProvider, XUnitVerifier>
    {
        /// <summary>
        /// The language version for the test to run in.
        /// </summary>
        public LanguageVersion LanguageVersion { get; init; } = TestConfiguration.DefaultCSharpLanguageVersion;

        /// <summary>
        /// Initializes a new instance of <see cref="Test"/>.
        /// </summary>
        public Test()
        {
            if (TestConfiguration.DefaultReferenceAssemblies is not null)
            {
                ReferenceAssemblies = TestConfiguration.DefaultReferenceAssemblies;
            }
        }

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
