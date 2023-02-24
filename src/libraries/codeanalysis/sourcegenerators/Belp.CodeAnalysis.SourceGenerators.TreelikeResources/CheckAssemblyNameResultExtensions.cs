namespace Belp.CodeAnalysis.SourceGenerators.TreelikeResources;

/// <summary>
/// Provides extensions for <see cref="CheckAssemblyNameResult"/>.
/// </summary>
public static class CheckAssemblyNameResultExtensions
{
    /// <summary>
    /// Converts the specified <see cref="CheckAssemblyNameResult"/> to a <see cref="DiagnosticDescriptor"/>.
    /// </summary>
    /// <param name="result">The result to convert.</param>
    /// <returns><see langword="null"/> if the assembly name is valid; otherwise, the diagnostic descriptor for the specified result.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="result"/> has an undefined value.</exception>
    public static DiagnosticDescriptor? ToDescriptor(this CheckAssemblyNameResult result)
    {
        return result switch
        {
            CheckAssemblyNameResult.Valid => null,
            CheckAssemblyNameResult.NullOrEmpty => DiagnosticDescriptors.SourceGenerators.MRG4001,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
    }
}
