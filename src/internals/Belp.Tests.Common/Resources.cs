namespace Belp.Tests.Common;
using IOPath = System.IO.Path;

/// <summary>
/// Provides methods for reading or writing resources for the running.
/// </summary>
public static partial class Resources
{
    /// <summary>
    /// Gets the base resources path.
    /// </summary>
    public static string Path { get; } = IOPath.Combine(
        IOPath.GetDirectoryName(typeof(Resources).Assembly.Location) ?? Environment.CurrentDirectory,
        "Resources"
    );
}
