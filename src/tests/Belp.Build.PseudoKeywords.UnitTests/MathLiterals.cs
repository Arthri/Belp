namespace Belp.Build.PseudoKeywords.UnitTests;

public partial class MathLiterals
{
    [Fact]
    public void φ_eq_1X2E6180339887498948()
    {
        φ.Should().Be(1.6180339887498948);
    }

    [Fact]
    public void π_eq_MathX2EPI()
    {
        π.Should().Be(Math.PI);
    }

    [Fact]
    public void τ_eq_MathX2ETau()
    {
        τ.Should().Be(Math.Tau);
    }
}
