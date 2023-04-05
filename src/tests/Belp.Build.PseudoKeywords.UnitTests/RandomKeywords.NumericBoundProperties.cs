namespace Belp.Build.PseudoKeywords.UnitTests;

public partial class RandomKeywords
{
    public partial class NumericBoundProperties
    {
        #region Random Inclusive

        [Fact]
        public void rsbyte_is_ge_X2D128_and_le_127()
        {
            rsbyte.Should().BeInRange(sbyte.MinValue, sbyte.MaxValue);
        }

        [Fact]
        public void rbyte_is_ge_0_and_le_255()
        {
            rbyte.Should().BeInRange(byte.MinValue, byte.MaxValue);
        }

        [Fact]
        public void rshort_is_ge_X2D32768_and_le_32767()
        {
            rshort.Should().BeInRange(short.MinValue, short.MaxValue);
        }

        [Fact]
        public void rushort_is_ge_0_and_le_65535()
        {
            rushort.Should().BeInRange(ushort.MinValue, ushort.MaxValue);
        }

        [Fact]
        public void rint_is_ge_X2D2147483648_and_le_2147483647()
        {
            rint.Should().BeInRange(int.MinValue, int.MaxValue);
        }

        [Fact]
        public void ruint_is_ge_0_and_le_4294967295()
        {
            ruint.Should().BeInRange(uint.MinValue, uint.MaxValue);
        }

        [Fact]
        public void rlong_is_ge_X2D9223372036854775808_and_le_9223372036854775807()
        {
            rlong.Should().BeInRange(long.MinValue, long.MaxValue);
        }

        [Fact]
        public void rulong_is_ge_0_and_le_18446744073709551615()
        {
            rulong.Should().BeInRange(ulong.MinValue, ulong.MaxValue);
        }

        #endregion



        #region Random Exclusive

        [Fact]
        public void resbyte_is_ge_X2D128_and_lt_127()
        {
            resbyte.Should().BeInRange(sbyte.MinValue, sbyte.MaxValue - 1);
        }

        [Fact]
        public void rebyte_is_ge_0_and_lt_255()
        {
            rebyte.Should().BeInRange(byte.MinValue, byte.MaxValue - 1);
        }

        [Fact]
        public void reshort_is_ge_X2D32768_and_lt_32767()
        {
            reshort.Should().BeInRange(short.MinValue, short.MaxValue - 1);
        }

        [Fact]
        public void reushort_is_ge_0_and_lt_65535()
        {
            reushort.Should().BeInRange(ushort.MinValue, ushort.MaxValue - 1);
        }

        [Fact]
        public void reint_is_ge_X2D2147483648_and_lt_2147483647()
        {
            reint.Should().BeInRange(int.MinValue, int.MaxValue - 1);
        }

        [Fact]
        public void reuint_is_ge_0_and_lt_4294967295()
        {
            reuint.Should().BeInRange(uint.MinValue, uint.MaxValue - 1);
        }

        [Fact]
        public void relong_is_ge_X2D9223372036854775808_and_lt_9223372036854775807()
        {
            relong.Should().BeInRange(long.MinValue, long.MaxValue - 1);
        }

        [Fact]
        public void reulong_is_ge_0_and_lt_18446744073709551615()
        {
            reulong.Should().BeInRange(ulong.MinValue, ulong.MaxValue - 1);
        }

        #endregion



        #region Random Positive Inclusive

        [Fact]
        public void rpsbyte_is_ge_0_and_le_127()
        {
            rpsbyte.Should().BeInRange(0, sbyte.MaxValue);
        }

        [Fact]
        public void rpshort_is_ge_0_and_le_32767()
        {
            rpshort.Should().BeInRange(0, short.MaxValue);
        }

        [Fact]
        public void rpint_is_ge_0_and_le_2147483647()
        {
            rpint.Should().BeInRange(0, int.MaxValue);
        }

        [Fact]
        public void rplong_is_ge_0_and_le_9223372036854775807()
        {
            rplong.Should().BeInRange(0, long.MaxValue);
        }

        #endregion



        #region Random Positive Exclusive

        [Fact]
        public void rpesbyte_is_ge_0_and_lt_127()
        {
            rpesbyte.Should().BeInRange(0, sbyte.MaxValue - 1);
        }

        [Fact]
        public void rpeshort_is_ge_0_and_lt_32767()
        {
            rpeshort.Should().BeInRange(0, short.MaxValue - 1);
        }

        [Fact]
        public void rpeint_is_ge_0_and_lt_2147483647()
        {
            rpeint.Should().BeInRange(0, int.MaxValue - 1);
        }

        [Fact]
        public void rpelong_is_ge_0_and_lt_9223372036854775807()
        {
            rpelong.Should().BeInRange(0, long.MaxValue - 1);
        }

        #endregion



        #region .NET Names



        #region Random Inclusive

        [Fact]
        public void rint8_is_ge_X2D128_and_le_127()
        {
            rint8.Should().BeInRange(sbyte.MinValue, sbyte.MaxValue);
        }

        [Fact]
        public void ruint8_is_ge_0_and_le_255()
        {
            ruint8.Should().BeInRange(byte.MinValue, byte.MaxValue);
        }

        [Fact]
        public void rint16_is_ge_X2D32768_and_le_32767()
        {
            rint16.Should().BeInRange(short.MinValue, short.MaxValue);
        }

        [Fact]
        public void ruint16_is_ge_0_and_le_65535()
        {
            ruint16.Should().BeInRange(ushort.MinValue, ushort.MaxValue);
        }

        [Fact]
        public void rint32_is_ge_X2D2147483648_and_le_2147483647()
        {
            rint32.Should().BeInRange(int.MinValue, int.MaxValue);
        }

        [Fact]
        public void ruint32_is_ge_0_and_le_4294967295()
        {
            ruint32.Should().BeInRange(uint.MinValue, uint.MaxValue);
        }

        [Fact]
        public void rint64_is_ge_X2D9223372036854775808_and_le_9223372036854775807()
        {
            rint64.Should().BeInRange(long.MinValue, long.MaxValue);
        }

        [Fact]
        public void ruint64_is_ge_0_and_le_18446744073709551615()
        {
            ruint64.Should().BeInRange(ulong.MinValue, ulong.MaxValue);
        }

        #endregion



        #region Random Exclusive

        [Fact]
        public void reint8_is_ge_X2D128_and_lt_127()
        {
            reint8.Should().BeInRange(sbyte.MinValue, sbyte.MaxValue - 1);
        }

        [Fact]
        public void reuint8_is_ge_0_and_lt_255()
        {
            reuint8.Should().BeInRange(byte.MinValue, byte.MaxValue - 1);
        }

        [Fact]
        public void reint16_is_ge_X2D32768_and_lt_32767()
        {
            reint16.Should().BeInRange(short.MinValue, short.MaxValue - 1);
        }

        [Fact]
        public void reuint16_is_ge_0_and_lt_65535()
        {
            reuint16.Should().BeInRange(ushort.MinValue, ushort.MaxValue - 1);
        }

        [Fact]
        public void reint32_is_ge_X2D2147483648_and_lt_2147483647()
        {
            reint32.Should().BeInRange(int.MinValue, int.MaxValue - 1);
        }

        [Fact]
        public void reuint32_is_ge_0_and_lt_4294967295()
        {
            reuint32.Should().BeInRange(uint.MinValue, uint.MaxValue - 1);
        }

        [Fact]
        public void reint64_is_ge_X2D9223372036854775808_and_lt_9223372036854775807()
        {
            reint64.Should().BeInRange(long.MinValue, long.MaxValue - 1);
        }

        [Fact]
        public void reuint64_is_ge_0_and_lt_18446744073709551615()
        {
            reuint64.Should().BeInRange(ulong.MinValue, ulong.MaxValue - 1);
        }

        #endregion



        #region Random Positive Inclusive

        [Fact]
        public void rpint8_is_ge_0_and_le_127()
        {
            rpint8.Should().BeInRange(0, sbyte.MaxValue);
        }

        [Fact]
        public void rpint16_is_ge_0_and_le_32767()
        {
            rpint16.Should().BeInRange(0, short.MaxValue);
        }

        [Fact]
        public void rpint32_is_ge_0_and_le_2147483647()
        {
            rpint32.Should().BeInRange(0, int.MaxValue);
        }

        [Fact]
        public void rpint64_is_ge_0_and_le_9223372036854775807()
        {
            rpint64.Should().BeInRange(0, long.MaxValue);
        }

        #endregion



        #region Random Positive Exclusive

        [Fact]
        public void rpeint8_is_ge_0_and_lt_127()
        {
            rpeint8.Should().BeInRange(0, sbyte.MaxValue - 1);
        }

        [Fact]
        public void rpeint16_is_ge_0_and_lt_32767()
        {
            rpeint16.Should().BeInRange(0, short.MaxValue - 1);
        }

        [Fact]
        public void rpeint32_is_ge_0_and_lt_2147483647()
        {
            rpeint32.Should().BeInRange(0, int.MaxValue - 1);
        }

        [Fact]
        public void rpeint64_is_ge_0_and_lt_9223372036854775807()
        {
            rpeint64.Should().BeInRange(0, long.MaxValue - 1);
        }

        #endregion



        #endregion
    }
}
