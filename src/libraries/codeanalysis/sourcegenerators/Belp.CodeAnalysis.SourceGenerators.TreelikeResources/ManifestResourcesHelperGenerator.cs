﻿namespace Belp.CodeAnalysis.SourceGenerators.TreelikeResources;

/// <summary>
/// Generates <see cref="ManifestResourcesHelper"/> in consuming projects.
/// </summary>
[Generator(LanguageNames.CSharp)]
public class ManifestResourcesHelperGenerator : IIncrementalGenerator
{
    /// <summary>
    /// Gets the source code for the embedded ManifestResourcesHelper.cs
    /// </summary>
    public static string Code_ManifestResourcesHelper { get; } = ManifestResourcesHelper.GetString($"{typeof(ManifestResourcesHelperGenerator).Namespace}.{nameof(ManifestResourcesHelper)}.cs") ?? throw new FileNotFoundException("Could not find embedded resource \"ManifestResourcesHelper.cs\"");

    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(static (context) => context.AddSource("ManifestResourcesHelper.cs", Code_ManifestResourcesHelper));
    }
}
