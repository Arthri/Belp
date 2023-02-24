using System.Runtime.CompilerServices;

namespace Belp.CodeAnalysis.SourceGenerators.TreelikeResources.UnitTests;

file static class Initializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        TestConfiguration.DefaultReferenceAssemblies = ReferenceAssemblies.NetStandard.NetStandard20;
    }
}
