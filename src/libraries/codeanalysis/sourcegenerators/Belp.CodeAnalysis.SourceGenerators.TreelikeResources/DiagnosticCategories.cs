namespace Belp.CodeAnalysis.SourceGenerators.TreelikeResources;

/// <summary>
/// Provides categories for diagnostics.
/// </summary>
public static class DiagnosticCategories
{
    /// <summary>
    /// Errors caused by the user.
    /// </summary>
    public const string UserError = $"{typeof(DiagnosticCategories).Namespace}.{nameof(UserError)}";
}
