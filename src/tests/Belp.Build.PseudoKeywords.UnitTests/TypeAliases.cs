namespace Belp.Build.PseudoKeywords.UnitTests;

public partial class TypeAliases
{
    #region Integer Types

    [Fact]
    public void int8_eq_sbyte()
    {
        typeof(int8).Should().Be<sbyte>();
    }

    [Fact]
    public void uint8_eq_byte()
    {
        typeof(uint8).Should().Be<byte>();
    }

    [Fact]
    public void int16_eq_short()
    {
        typeof(int16).Should().Be<short>();
    }

    [Fact]
    public void uint16_eq_ushort()
    {
        typeof(uint16).Should().Be<ushort>();
    }

    [Fact]
    public void int32_eq_int()
    {
        typeof(int32).Should().Be<int>();
    }

    [Fact]
    public void uint32_eq_uint()
    {
        typeof(uint32).Should().Be<uint>();
    }

    [Fact]
    public void int64_eq_long()
    {
        typeof(int64).Should().Be<long>();
    }

    [Fact]
    public void uint64_eq_ulong()
    {
        typeof(uint64).Should().Be<ulong>();
    }

    #endregion



    #region Floating-Point Types

    [Fact]
    public void half_eq_SystemX2EHalf()
    {
#pragma warning disable IDE0001 // Simplify Names
        typeof(half).Should().Be<global::System.Half>();
#pragma warning restore IDE0001 // Simplify Names
    }

    [Fact]
    public void fp16_eq_SystemX2EHalf()
    {
#pragma warning disable IDE0001 // Simplify Names
        typeof(fp16).Should().Be<global::System.Half>();
#pragma warning restore IDE0001 // Simplify Names
    }

    [Fact]
    public void float16_eq_SystemX2EHalf()
    {
#pragma warning disable IDE0001 // Simplify Names
        typeof(float16).Should().Be<global::System.Half>();
#pragma warning restore IDE0001 // Simplify Names
    }

    [Fact]
    public void single_eq_float()
    {
        typeof(single).Should().Be<float>();
    }

    [Fact]
    public void fp32_eq_float()
    {
        typeof(fp32).Should().Be<float>();
    }

    [Fact]
    public void float32_eq_float()
    {
        typeof(float32).Should().Be<float>();
    }

    [Fact]
    public void fp64_eq_double()
    {
        typeof(fp64).Should().Be<double>();
    }

    [Fact]
    public void float64_eq_double()
    {
        typeof(float64).Should().Be<double>();
    }

    #endregion



    #region Other Numeric Types

    [Fact]
    public void bigint_eq_SystemX2ENumericsX2EBigInteger()
    {
#pragma warning disable IDE0001 // Simplify Names
        typeof(bigint).Should().Be<global::System.Numerics.BigInteger>();
#pragma warning restore IDE0001 // Simplify Names
    }

    [Fact]
    public void complex_eq_SystemX2ENumericsX2EComplex()
    {
#pragma warning disable IDE0001 // Simplify Names
        typeof(complex).Should().Be<global::System.Numerics.Complex>();
#pragma warning restore IDE0001 // Simplify Names
    }

    #endregion



    #region Temporal Types

    [Fact]
    public void datetime_eq_SystemX2EDateTime()
    {
#pragma warning disable IDE0001 // Simplify Names
        typeof(datetime).Should().Be<global::System.DateTime>();
#pragma warning restore IDE0001 // Simplify Names
    }

    [Fact]
    public void date_eq_SystemX2EDateOnly()
    {
#pragma warning disable IDE0001 // Simplify Names
        typeof(date).Should().Be<global::System.DateOnly>();
#pragma warning restore IDE0001 // Simplify Names
    }

    [Fact]
    public void time_eq_SystemX2ETimeOnly()
    {
#pragma warning disable IDE0001 // Simplify Names
        typeof(time).Should().Be<global::System.TimeOnly>();
#pragma warning restore IDE0001 // Simplify Names
    }

    [Fact]
    public void timespan_eq_SystemX2ETimeSpan()
    {
#pragma warning disable IDE0001 // Simplify Names
        typeof(timespan).Should().Be<global::System.TimeSpan>();
#pragma warning restore IDE0001 // Simplify Names
    }

    #endregion



    #region Other Types

    [Fact]
    public void boolean_eq_bool()
    {
        typeof(boolean).Should().Be<bool>();
    }

    #endregion
}
