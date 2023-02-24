using System.Runtime.CompilerServices;

namespace Belp.CodeAnalysis.ManifestResourceGenerators.UnitTests;

file static class Initializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        TestConfiguration.DefaultReferenceAssemblies = ReferenceAssemblies.NetStandard.NetStandard20;
    }
}
