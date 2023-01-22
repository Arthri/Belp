namespace Belp.Tests;

/// <summary>
/// Provides methods for reading or writing resources for the running.
/// </summary>
public static partial class Resources
{
    /// <summary>
    /// Gets the base resources path.
    /// </summary>
    public static string BasePath { get; } = Path.Combine(
        Path.GetDirectoryName(typeof(Resources).Assembly.Location) ?? "/",
        "Resources"
    );
}
