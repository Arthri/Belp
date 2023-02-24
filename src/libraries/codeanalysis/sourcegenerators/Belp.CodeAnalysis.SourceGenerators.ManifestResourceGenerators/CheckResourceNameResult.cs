namespace Belp.CodeAnalysis.SourceGenerators.ManifestResourceGenerators;

/// <summary>
/// Represents the output of a resource name check.
/// </summary>
public enum CheckResourceNameResult
{
    /// <summary>
    /// Indicates the resource name is valid.
    /// </summary>
    Valid = 1,

    /// <summary>
    /// Indicates the resource name ends with a dot.
    /// </summary>
    EndsWithDot = 4002,

    /// <summary>
    /// Indicates the resource name is null or has zero length.
    /// </summary>
    NullOrEmpty = 4003,

    /// <summary>
    /// Indicates the resource name doesn't contain dots.
    /// </summary>
    ContainsNoDots = 4004,

    /// <summary>
    /// Indicates the resource name contains two or more consecutive dots.
    /// </summary>
    ContainsConsecutiveDots = 4005,
}
