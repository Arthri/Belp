using Microsoft.Build.Locator;
using System.Runtime.CompilerServices;

static file class Initializer
{
    [ModuleInitializer]
    public static void InitializeModule()
    {
        if (MSBuildLocator.IsRegistered)
        {
            return;
        }

        VisualStudioInstance? latestInstance = MSBuildLocator
            .QueryVisualStudioInstances()
            .Where(static i => i.DiscoveryType == DiscoveryType.DotNetSdk)
            .OrderByDescending(static i => i.Version)
            .FirstOrDefault()
            ;

        if (latestInstance is null)
        {
            throw new InvalidOperationException(".NET SDK not found");
        }

        if (latestInstance.Version.Major < 5)
        {
            throw new InvalidOperationException(".NET SDK 5 or higher not found");
        }

        MSBuildLocator.RegisterInstance(latestInstance);
    }
}
