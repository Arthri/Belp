using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace Belp.CodeAnalysis.ManifestResourceGenerators.UnitTests;

public static partial class ManifestResourcesGenerator
{
    public static (string filename, SourceText content) Source_ManifestResourcesHelper => (
        """Belp.CodeAnalysis.ManifestResourceGenerators\Belp.CodeAnalysis.ManifestResourceGenerators.ManifestResourcesGenerator\ManifestResourcesHelper.cs""",
        SourceText.From(ManifestResourceGenerators.ManifestResourcesGenerator.Code_ManifestResourcesHelper, Encoding.UTF8)
    );
}
