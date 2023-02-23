using IOPath = System.IO.Path;

namespace Belp.Tests.Common;

/// <summary>
/// Provides methods for reading or writing resources for the running.
/// </summary>
public static partial class Resources
{
    /// <summary>
    /// Gets the path where the resources folder is located.
    /// </summary>
    public static string BasePath { get; } = IOPath.GetDirectoryName(typeof(Resources).Assembly.Location) ?? Environment.CurrentDirectory;

    /// <summary>
    /// Gets the base resources path.
    /// </summary>
    public static string Path { get; } = IOPath.Combine(
        BasePath,
        "Resources"
    );
}
