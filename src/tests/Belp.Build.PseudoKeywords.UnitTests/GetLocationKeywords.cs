using System.Runtime.CompilerServices;

namespace Belp.Build.PseudoKeywords.UnitTests;

public partial class GetLocationKeywords
{
    [Fact]
    public void linenum_is_420()
    {
#line 420
        linenum().Should().Be(420);
    }

    [Fact]
    public void currentfile_is_FooX2Ecs()
    {
#line 420 "Foo.cs"
        currentfile().Should().NotBeEmpty().And.Be(GetFilePath());

        static string GetFilePath([CallerFilePath] string path = "")
        {
            return path;
        }
    }
}
