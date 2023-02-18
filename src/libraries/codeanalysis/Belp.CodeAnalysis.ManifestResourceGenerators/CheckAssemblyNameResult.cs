namespace Belp.CodeAnalysis.ManifestResourceGenerators;

/// <summary>
/// Represents the output of an assembly name check.
/// </summary>
public enum CheckAssemblyNameResult
{
    /// <summary>
    /// Indicates the assembly name is valid.
    /// </summary>
    Valid = 1,

    /// <summary>
    /// Indicates the assembly name is null or has zero length.
    /// </summary>
    NullOrEmpty = 4001,
}
