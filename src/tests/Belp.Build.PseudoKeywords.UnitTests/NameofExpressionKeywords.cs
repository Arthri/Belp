namespace Belp.Build.PseudoKeywords.UnitTests;

public partial class NameofExpressionKeywords
{
    [Fact]
    public void nameofexprX28FuncX3CintX2C_stringX3EX29_eq_expression()
    {
        nameofexpr(string (int foo) => "f")
            .Should()
            .Be("""
            string (int foo) => "f"
            """)
            ;
    }

    [Fact]
    public void nameofexprX28ActionX3CintX2C_stringX2C_DateTimeX3EX29_eq_expression()
    {
#pragma warning disable IDE0001 // Simplify Names
        nameofexpr(void (int r, string f, DateTime d) => _ = 51 + 42)
#pragma warning restore IDE0001 // Simplify Names
            .Should()
            .Be("""
            void (int r, string f, DateTime d) => _ = 51 + 42
            """)
            ;
    }

    [Fact]
    public void nameofexprX28intX29_eq_expression()
    {
        nameofexpr(3259594).Should().Be("3259594");
    }

    [Fact]
    public void nameofexprX28int_expressionX29_eq_expression()
    {
        nameofexpr(123 + 345 * 234 / 344 - 121).Should().Be("123 + 345 * 234 / 344 - 121");
    }
}
