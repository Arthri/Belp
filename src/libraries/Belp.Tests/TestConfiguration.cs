using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Testing;

namespace Belp.Tests;

/// <summary>
/// Provides the global configuration for all tests.
/// </summary>
public static class TestConfiguration
{
    /// <summary>
    /// Gets or sets the default reference assemblies for all tests.
    /// </summary>
    public static ReferenceAssemblies? DefaultReferenceAssemblies { get; set; }



    /// <summary>
    /// Getse or sets the default language version for all C# tests.
    /// </summary>
    public static LanguageVersion DefaultCSharpLanguageVersion { get; set; }
}
