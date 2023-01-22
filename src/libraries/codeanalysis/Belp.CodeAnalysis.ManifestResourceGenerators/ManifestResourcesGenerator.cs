using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Belp.CodeAnalysis.ManifestResourceGenerators;

/// <summary>
/// Provides the generation of strongly typed manifest resource names.
/// </summary>
[Generator(LanguageNames.CSharp)]
public class ManifestResourcesGenerator : IIncrementalGenerator
{
    /// <summary>
    /// Gets the source code for the embedded ManifestResourcesHelper.cs
    /// </summary>
    public static string Code_ManifestResourcesHelper { get; } = ManifestResourcesHelper.GetString($"{nameof(Belp)}.{nameof(CodeAnalysis)}.{nameof(ManifestResourceGenerators)}.{nameof(ManifestResourcesHelper)}.cs") ?? throw new FileNotFoundException("Could not find embedded resource \"ManifestResourcesHelper.cs\"");

    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(Execute_GenerateStaticResourceHelpers);

        IncrementalValueProvider<string?> assemblyName = context.CompilationProvider.Select(static (compilation, cancellationToken) => compilation.AssemblyName);

        context.RegisterSourceOutput(assemblyName, static (context, assemblyName) =>
        {
            if (CheckAssemblyName(assemblyName) is { } checkAssemblyNameResult)
            {
                context.ReportDiagnostic(
                    Diagnostic.Create(
                        checkAssemblyNameResult,
                        Location.None
                    )
                );
                return;
            }
        });

        IncrementalValuesProvider<string> resourceNames = context
            .AdditionalTextsProvider
            .Combine(context.AnalyzerConfigOptionsProvider)
            .SelectMany(static (providers, cancellationToken) =>
            {
                (AdditionalText additionalText, AnalyzerConfigOptionsProvider analyzerOptions) = providers;
                AnalyzerConfigOptions options = analyzerOptions.GetOptions(additionalText);

                return options.TryGetValue("build_metadata.AdditionalFiles.TargetSourceGenerator", out string? targetSourceGenerator)
                    && targetSourceGenerator == "ManifestResourcesGenerator"
                    && options.TryGetValue("build_metadata.AdditionalFiles.ManifestResourceName", out string? manifestResourceName)
                    ? ImmutableArray.Create(manifestResourceName)
                    : ImmutableArray<string>.Empty
                    ;
            })
            ;

        context.RegisterSourceOutput(resourceNames.Combine(assemblyName), Execute_GenerateResourceNameHierarchy);

        // Gather the all the resources under a namespace
        IncrementalValuesProvider<(ResourceNamespace Namespace, string? AssemblyName)> resourceNamespaces = resourceNames
            .Collect()
            .SelectMany(static (resouceNames, cancellationToken) =>
            {
                var namespacesMap = new Dictionary<string, List<string>>();

                foreach (string? resourceName in resouceNames)
                {
                    if (CheckResourceName(resourceName) is not null)
                    {
                        // Diagnostic report is handled elsewhere
                        continue;
                    }

                    for (int i = 0; (i = resourceName.IndexOf('.', i)) != -1; i++)
                    {
                        string resourceNamespace = resourceName[..i];
                        if (namespacesMap.TryGetValue(resourceNamespace, out List<string> resources))
                        {
                            resources.Add(resourceName);
                        }
                        else
                        {
                            namespacesMap[resourceNamespace] = new List<string>() { resourceName };
                        }
                    }
                }

                var resourceNamespaces = new ResourceNamespace[namespacesMap.Count];
                {
                    int i = 0;
                    foreach ((string resourceNamespace, List<string> resources) in namespacesMap)
                    {
                        resourceNamespaces[i++] = new ResourceNamespace(
                            resourceNamespace,
                            new(resources.ToArray())
                        );
                    }
                }
                Array.Sort(resourceNamespaces, static (a, b) => a.Namespace.CompareTo(b.Namespace));

                return ImmutableArray.Create(resourceNamespaces);
            })
            .Combine(assemblyName)
            ;

        context.RegisterSourceOutput(resourceNamespaces, Execute_GenerateResourceNamespaces);
    }

    /// <summary>
    /// Determines if the specified assembly name is valid.
    /// </summary>
    /// <param name="assemblyName">The assembly name to check.</param>
    /// <returns><see langword="null"/> if the specified assembly name is valid; otherwise, a diagnostic descriptor describing the invalidity.</returns>
    public static DiagnosticDescriptor? CheckAssemblyName([NotNullWhen(false)] string? assemblyName)
    {
#pragma warning disable IDE0046 // Convert to conditional expression
        if (assemblyName is null || assemblyName.Length < 1)
        {
            return (DiagnosticDescriptor?)DiagnosticDescriptors.SourceGenerators.MRG4001;
        }

        return null;
#pragma warning restore IDE0046 // Convert to conditional expression
    }

    /// <summary>
    /// Determines if the specified resource name is valid.
    /// </summary>
    /// <param name="resourceName">The resource name to check.</param>
    /// <returns><see langword="null"/> if the specified resource name is valid; otherwise, a diagnostic descriptor describing the invalidity.</returns>
    public static DiagnosticDescriptor? CheckResourceName([NotNullWhen(false)] string? resourceName)
    {
        if (resourceName is null or { Length: 0 })
        {
            return DiagnosticDescriptors.SourceGenerators.ManifestResourcesGenerator.MRGN4003;
        }

        if (resourceName[^1] == '.')
        {
            return DiagnosticDescriptors.SourceGenerators.ManifestResourcesGenerator.MRGN4002;
        }

        if (resourceName.Contains(".."))
        {
            return DiagnosticDescriptors.SourceGenerators.ManifestResourcesGenerator.MRGN4005;
        }

#pragma warning disable IDE0046 // Convert to conditional expression
        if (resourceName.IndexOf('.') == -1)
        {
            return DiagnosticDescriptors.SourceGenerators.ManifestResourcesGenerator.MRGN4004;
        }

        return null;
#pragma warning restore IDE0046 // Convert to conditional expression
    }

    /// <summary>
    /// Represents information used to generate namespace and types.
    /// </summary>
    public readonly ref struct NamespaceInformation
    {
        /// <summary>
        /// Gets the namespace to declare the types in.
        /// </summary>
        public readonly string DeclarationNamespace;

        /// <summary>
        /// Gets the namespaces that will be mapped to types.
        /// </summary>
        public readonly Span<string> Namespaces;

        /// <summary>
        /// Initializes a new instance of <see cref="NamespaceInformation"/> from the specified arguments.
        /// </summary>
        /// <param name="declarationNamespace">The namespace to declare the types in.</param>
        /// <param name="namespaces">The namespaces that will be mapped to types.</param>
        public NamespaceInformation(string declarationNamespace, Span<string> namespaces)
        {
            DeclarationNamespace = declarationNamespace;
            Namespaces = namespaces;
        }
    }

    /// <summary>
    /// Extracts namespace information from the specified resource name.
    /// </summary>
    /// <param name="assemblyName">The assembly name to base off of.</param>
    /// <param name="resourceName">The resource name.</param>
    /// <returns>Namespace information.</returns>
    public static NamespaceInformation GetNamespaces(string assemblyName, string resourceName)
    {
        if (resourceName.Length > assemblyName.Length
         && string.CompareOrdinal(assemblyName, 0, resourceName, 0, assemblyName.Length) == 0
         && resourceName[assemblyName.Length] == '.'
         )
        {
            // Assuming assemblyName = "Assembly.Name", then permit "Assembly.Name.*" but disallow "Assembly.Name"
            // CheckResourceName ensures resourceName is either Assembly.Name or Assembly.Name.*, because trailing dots are not allowed

            // If the resource name starts with the assembly name
            // then return assembly name as the declaration namespace
            // and remove the assembly name from the resource name then return as namespaces
            int dotCount = 1;
            {
                for (int i = 0; (i = assemblyName.IndexOf('.', i)) > -1; i++)
                {
                    dotCount++;
                }
            }

            return new(assemblyName, resourceName.Split('.').AsSpan(dotCount));
        }
        else
        {
            // If the resource name doesn't start with the assembly name,
            // then create the first name as the declaration namespace
            // and the others as namespaces

            return new(resourceName[..resourceName.IndexOf('.')], resourceName.Split('.').AsSpan(1));
        }
    }

    private static void Execute_GenerateStaticResourceHelpers(IncrementalGeneratorPostInitializationContext context)
    {
        context.AddSource("ManifestResourcesHelper.cs", Code_ManifestResourcesHelper);
    }

    private static void Execute_GenerateResourceNameHierarchy(
        SourceProductionContext context,
        (string ManifestResourceName, string? AssemblyName) info
    )
    {
        (string resourceName, string? assemblyName) = info;

        if (CheckAssemblyName(assemblyName) is { } assemblyNameCheckResult)
        {
            return;
        }

        if (CheckResourceName(resourceName) is { } resourceNameCheckResult)
        {
            context.ReportDiagnostic(
                Diagnostic.Create(
                    resourceNameCheckResult,
                    Location.None
                )
            );
            return;
        }

        NamespaceInformation namespaceInformation = GetNamespaces(assemblyName, resourceName);
        Span<string> namespaces = namespaceInformation.Namespaces;

        var codeBuilder = new IndentedStringBuilder(
            new StringBuilder($$"""
                // <auto-generated/>
                #pragma warning disable
                #nullable disable

                namespace {{namespaceInformation.DeclarationNamespace}}
                {
                    static partial class ManifestResources
                    {

                """
            ),
            8
        );
        const int IndentSize = 4;

        for (int i = 0; i < namespaces.Length - 1; i++)
        {
            string name = namespaces[i];
            _ = codeBuilder
                .AppendLine($$"""public static partial class {{name}}""")
                .AppendLine($$"""{""")
                ;

            codeBuilder.CurrentIndent += IndentSize;
        }

        _ = codeBuilder
            .AppendLine($$"""public const string {{namespaces[^1]}} = "{{resourceName}}";""")
            ;

        for (int i = 0; i < namespaces.Length - 1; i++)
        {
            codeBuilder.CurrentIndent -= IndentSize;
            _ = codeBuilder
                .AppendLine("}")
                ;
        }

        _ = codeBuilder.Builder.Append("""
                }
            }

            """);

        context.AddSource(
            resourceName + ".cs",
            codeBuilder.ToString()
        );
    }

    private static void Execute_GenerateResourceNamespaces(
        SourceProductionContext context,
        (ResourceNamespace Namespace, string? AssemblyName) info
    )
    {
        (ResourceNamespace resourceNamespace, string? assemblyName) = info;
        if (CheckAssemblyName(assemblyName) is { })
        {
            return;
        }

        NamespaceInformation namespaceInformation = GetNamespaces(assemblyName, resourceNamespace.Namespace + ".Resources");
        Span<string> namespaces = namespaceInformation.Namespaces;
        var codeBuilder = new IndentedStringBuilder(
            new StringBuilder($$"""
                // <auto-generated/>
                #pragma warning disable
                #nullable disable
                    
                namespace {{namespaceInformation.DeclarationNamespace}}
                {
                    static partial class ManifestResources
                    {

                """
            ),
            8
        );
        const int IndentSize = 4;

        for (int i = 0; i < namespaces.Length - 1; i++)
        {
            string name = namespaces[i];
            _ = codeBuilder
                .AppendLine($$"""public static partial class {{name}}""")
                .AppendLine($$"""{""")
                ;

            codeBuilder.CurrentIndent += IndentSize;
        }

        _ = codeBuilder
            .AppendLine($$""""""public static global::System.Collections.Generic.IReadOnlyList<string> Resources { get; } = new string[] { """"{{string.Join("\"\"\"\", \"\"\"\"", resourceNamespace.Resources)}}"""" };"""""")
        ;

        for (int i = 0; i < namespaces.Length - 1; i++)
        {
            codeBuilder.CurrentIndent -= IndentSize;
            _ = codeBuilder
                .AppendLine("}")
                ;
        }

        _ = codeBuilder.Builder.Append("""
                }
            }

            """);

        context.AddSource(
            $"Resources.{resourceNamespace.Namespace}.cs",
            codeBuilder.ToString()
        );
    }
}
