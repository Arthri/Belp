namespace Belp.Build.PseudoKeywords.UnitTests;

public partial class BoolAlternativeLiterals
{
    [Fact]
    public void False_eq_false()
    {
        False.Should().BeFalse();
    }

    [Fact]
    public void True_eq_true()
    {
        True.Should().BeTrue();
    }



    [Fact]
    public void Off_eq_false()
    {
        Off.Should().BeFalse();
    }

    [Fact]
    public void off_eq_false()
    {
        off.Should().BeFalse();
    }

    [Fact]
    public void On_eq_true()
    {
        On.Should().BeTrue();
    }

    [Fact]
    public void on_eq_true()
    {
        on.Should().BeTrue();
    }



    [Fact]
    public void No_eq_false()
    {
        No.Should().BeFalse();
    }

    [Fact]
    public void no_eq_false()
    {
        no.Should().BeFalse();
    }

    [Fact]
    public void Yes_eq_true()
    {
        Yes.Should().BeTrue();
    }

    [Fact]
    public void yes_eq_true()
    {
        yes.Should().BeTrue();
    }
}
