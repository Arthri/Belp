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
        /// Dummy field used to carry project name across constructor/inheritance boundaries.
        /// </summary>
        [ThreadStatic]
        private static string? ProjectName;

        /// <summary>
        /// Stores the project name to prevent it from changing.
        /// </summary>
        private string? _projectName;

        // This property is used at least once in AnalyzerTest's constructor, allowing
        // us to cache it as soon as a Test is initialized.
        /// <inheritdoc />
        protected override string DefaultTestProjectName => _projectName ??= ProjectName ?? base.DefaultTestProjectName;



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

        /// <summary>
        /// Initializes a new instance of <see cref="Test"/> with the specified project name.
        /// </summary>
        /// <param name="projectName">The new test project's name.</param>
        /// <param name="construct">An optional function that creates the <see cref="Test"/> to modify.</param>
        /// <returns>A new <see cref="Test"/> with the specified project name.</returns>
        public static Test From(string projectName, Func<Test>? construct = null)
        {
            ProjectName = projectName;
            CSharpIncrementalSourceGeneratorVerifier<TSourceGenerator>.Test result = construct is null
                ? new Test()
                : construct()
                ;
            ProjectName = null;

            return result;
        }
    }
}
