using Belp.Tests;
using Microsoft.CodeAnalysis.Testing;
using System.Runtime.CompilerServices;

namespace Belp.CodeAnalysis.ManifestResourceGenerators.UnitTests;

internal class Initializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        TestConfiguration.DefaultReferenceAssemblies = ReferenceAssemblies.NetStandard.NetStandard20;
    }
}
