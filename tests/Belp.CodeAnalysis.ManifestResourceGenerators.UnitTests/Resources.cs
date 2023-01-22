using IOPath = System.IO.Path;

namespace Belp.CodeAnalysis.ManifestResourceGenerators.UnitTests;

internal static partial class Resources
{
    public static string Path { get; } = IOPath.Combine(
        IOPath.GetDirectoryName(typeof(Resources).Assembly.Location) ?? "/",
        "Resources"
    );
}
