namespace Belp.CodeAnalysis.SourceGenerators.TreelikeResources;

/// <summary>
/// Provides extensions for <see cref="CheckResourceNameResult"/>.
/// </summary>
public static class CheckResourceNameResultExtensions
{
    /// <summary>
    /// Converts the specified <see cref="CheckResourceNameResult"/> to a <see cref="DiagnosticDescriptor"/>.
    /// </summary>
    /// <param name="result">The result to convert.</param>
    /// <returns><see langword="null"/> if the resource name is valid; otherwise, the diagnostic descriptor for the specified result.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="result"/> has an undefined value.</exception>
    public static DiagnosticDescriptor? ToDescriptor(this CheckResourceNameResult result)
    {
        return result switch
        {
            CheckResourceNameResult.Valid => null,
            CheckResourceNameResult.EndsWithDot => DiagnosticDescriptors.SourceGenerators.ResourceTreeGenerator.MRGN4002,
            CheckResourceNameResult.NullOrEmpty => DiagnosticDescriptors.SourceGenerators.ResourceTreeGenerator.MRGN4003,
            CheckResourceNameResult.ContainsNoDots => DiagnosticDescriptors.SourceGenerators.ResourceTreeGenerator.MRGN4004,
            CheckResourceNameResult.ContainsConsecutiveDots => DiagnosticDescriptors.SourceGenerators.ResourceTreeGenerator.MRGN4005,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
    }
}
