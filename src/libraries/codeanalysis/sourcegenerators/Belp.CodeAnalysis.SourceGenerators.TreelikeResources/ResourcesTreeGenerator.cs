﻿using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Belp.CodeAnalysis.SourceGenerators.TreelikeResources;

/// <summary>
/// Provides the generation of strongly typed manifest resource names.
/// </summary>
[Generator(LanguageNames.CSharp)]
public class ResourcesTreeGenerator : IIncrementalGenerator
{
    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValueProvider<string?> assemblyName = context.CompilationProvider.Select(static (compilation, cancellationToken) => compilation.AssemblyName);

        context.RegisterSourceOutput(assemblyName, static (context, assemblyName) =>
        {
            if (CheckAssemblyName(assemblyName).ToDescriptor() is { } checkAssemblyNameDescriptor)
            {
                context.ReportDiagnostic(
                    Diagnostic.Create(
                        checkAssemblyNameDescriptor,
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
                    && targetSourceGenerator == typeof(ResourcesTreeGenerator).FullName
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
                    if (CheckResourceName(resourceName) is not CheckResourceNameResult.Valid)
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
                        string[] finalResources = resources.ToArray();
                        Array.Sort(finalResources);

                        resourceNamespaces[i++] = new ResourceNamespace(
                            resourceNamespace,
                            new(finalResources)
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
    /// <returns>A result representing the validity of the specified assembly name.</returns>
    public static CheckAssemblyNameResult CheckAssemblyName([NotNullWhen(true)] string? assemblyName)
    {
#pragma warning disable IDE0046 // Convert to conditional expression
        if (assemblyName is null || assemblyName.Length < 1)
        {
            return CheckAssemblyNameResult.NullOrEmpty;
        }

        return CheckAssemblyNameResult.Valid;
#pragma warning restore IDE0046 // Convert to conditional expression
    }

    /// <summary>
    /// Determines if the specified resource name is valid.
    /// </summary>
    /// <param name="resourceName">The resource name to check.</param>
    /// <returns>A result representing the validity of the specified assembly name.</returns>
    public static CheckResourceNameResult CheckResourceName([NotNullWhen(true)] string? resourceName)
    {
        if (resourceName is null or { Length: 0 })
        {
            return CheckResourceNameResult.NullOrEmpty;
        }

        if (resourceName.IndexOf('.') == -1)
        {
            return CheckResourceNameResult.ContainsNoDots;
        }

        if (resourceName.Contains(".."))
        {
            return CheckResourceNameResult.ContainsConsecutiveDots;
        }

#pragma warning disable IDE0046 // Convert to conditional expression
        if (resourceName[^1] == '.')
        {
            return CheckResourceNameResult.EndsWithDot;
        }

        return CheckResourceNameResult.Valid;
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

    private static void Execute_GenerateResourceNameHierarchy(
        SourceProductionContext context,
        (string ManifestResourceName, string? AssemblyName) info
    )
    {
        (string resourceName, string? assemblyName) = info;

        if (CheckAssemblyName(assemblyName) is not CheckAssemblyNameResult.Valid)
        {
            return;
        }

        if (CheckResourceName(resourceName).ToDescriptor() is { } resourceNameCheckDescriptor)
        {
            context.ReportDiagnostic(
                Diagnostic.Create(
                    resourceNameCheckDescriptor,
                    Location.None
                )
            );
            return;
        }

        NamespaceInformation namespaceInformation = GetNamespaces(assemblyName, resourceName);
        Span<string> namespaces = namespaceInformation.Namespaces;

        CodeBuilder codeBuilder = new CodeBuilder(new StringBuilder(360))
            .AppendLine($$"""// <auto-generated/>""")
            .AppendLine($$"""#pragma warning disable""")
            .AppendLine($$"""#nullable disable""")
            .AppendLine()
            .AppendLine($$"""namespace {{namespaceInformation.DeclarationNamespace}}""")
            .OpenBrace
            .AppendLine($$"""static partial class ManifestResources""")
            .OpenBrace
            ;

        for (int i = 0; i < namespaces.Length - 1; i++)
        {
            string name = namespaces[i];
            _ = codeBuilder
                .AppendLine($$"""public static partial class {{name}}""")
                .OpenBrace
                ;
        }

        _ = codeBuilder
            .AppendLine($$"""public const string {{namespaces[^1]}} = "{{resourceName}}";""")
            .ShutBrace(namespaces.Length - 1 + 2)
            ;

        context.AddSource(
            $"{resourceName}.cs",
            codeBuilder.ToString()
        );
    }

    private static void Execute_GenerateResourceNamespaces(
        SourceProductionContext context,
        (ResourceNamespace Namespace, string? AssemblyName) info
    )
    {
        (ResourceNamespace resourceNamespace, string? assemblyName) = info;
        if (CheckAssemblyName(assemblyName) is not CheckAssemblyNameResult.Valid)
        {
            return;
        }

        NamespaceInformation namespaceInformation = GetNamespaces(assemblyName, resourceNamespace.Namespace + ".Resources");
        Span<string> namespaces = namespaceInformation.Namespaces;
        CodeBuilder codeBuilder = new CodeBuilder(new StringBuilder(480))
            .AppendLine($$"""// <auto-generated/>""")
            .AppendLine($$"""#pragma warning disable""")
            .AppendLine($$"""#nullable disable""")
            .AppendLine()
            .AppendLine($$"""namespace {{namespaceInformation.DeclarationNamespace}}""")
            .OpenBrace
            .AppendLine($$"""static partial class ManifestResources""")
            .OpenBrace
            ;

        for (int i = 0; i < namespaces.Length - 1; i++)
        {
            string name = namespaces[i];
            _ = codeBuilder
                .AppendLine($$"""public static partial class {{name}}""")
                .OpenBrace
                ;
        }

        _ = codeBuilder
            .AppendLine($$"""public static global::System.Collections.Generic.IReadOnlyList<string> Resources { get; } = new string[]""")
            .OpenBrace
        ;

        foreach (string resource in resourceNamespace.Resources)
        {
            _ = codeBuilder
                .AppendLine($$""""""
                """"{{resource}}"""",
                """""")
                ;
        }

        _ = codeBuilder
            .Undent
            .AppendLine("};")
            .ShutBrace(namespaces.Length - 1 + 2)
            ;

        context.AddSource(
            $"Resources.{resourceNamespace.Namespace}.cs",
            codeBuilder.ToString()
        );
    }
}
