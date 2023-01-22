namespace Belp.CodeAnalysis.ManifestResourceGenerators.UnitTests;

internal static partial class Resources
{
    public static string BasePath { get; } = Path.Combine(
        Path.GetDirectoryName(typeof(Resources).Assembly.Location) ?? "/",
        "Resources"
    );
}
