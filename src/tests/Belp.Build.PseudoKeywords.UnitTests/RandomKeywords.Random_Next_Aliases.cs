namespace Belp.Build.PseudoKeywords.UnitTests;

public partial class RandomKeywords
{
    public partial class Random_Next_Aliases
    {
        #region Random.Next

        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        [InlineData(420)]
        [InlineData(694561)]
        public void rnextX28intX29_should_generate_number_in_range(int maxValue)
        {
            rnext(maxValue).Should().BeInRange(0, maxValue - 1);
        }

        [Theory]
        [InlineData(12, 45)]
        [InlineData(3402, 5205)]
        [InlineData(-400, 400)]
        [InlineData(-53456, 45590)]
        [InlineData(-324504, 3454354)]
        [InlineData(-234545, -345)]
        public void rnextX28intX2C_intX29_should_generate_number_in_range(int minValue, int maxValue)
        {
            rnext(minValue, maxValue).Should().BeInRange(minValue, maxValue - 1);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        [InlineData(420)]
        [InlineData(694561)]
        [InlineData(234324543)]
        [InlineData(1244945695496)]
        public void rnextX28longX29_should_generate_number_in_range(long maxValue)
        {
            rnext(maxValue).Should().BeInRange(0, maxValue - 1);
        }

        [Theory]
        [InlineData(12, 45)]
        [InlineData(3402, 5205)]
        [InlineData(-400, 400)]
        [InlineData(-53456, 45590)]
        [InlineData(-324504, 3454354)]
        [InlineData(-234545, -345)]
        [InlineData(-3454395943, 4569549694)]
        [InlineData(-214323490, 5645643)]
        [InlineData(23445633455, 345623445644)]
        [InlineData(-253142343142, -456)]
        public void rnextX28longX2C_longX29_should_generate_number_in_range(long minValue, long maxValue)
        {
            rnext(minValue, maxValue).Should().BeInRange(minValue, maxValue - 1);
        }

        #endregion



        #region Random.Next Explicit Type

        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        [InlineData(420)]
        [InlineData(694561)]
        public void rnextintX28intX29_should_generate_number_in_range(int maxValue)
        {
            rnextint(maxValue).Should().BeInRange(0, maxValue - 1);
        }

        [Theory]
        [InlineData(12, 45)]
        [InlineData(3402, 5205)]
        [InlineData(-400, 400)]
        [InlineData(-53456, 45590)]
        [InlineData(-324504, 3454354)]
        [InlineData(-234545, -345)]
        public void rnextintX28intX2C_intX29_should_generate_number_in_range(int minValue, int maxValue)
        {
            rnextint(minValue, maxValue).Should().BeInRange(minValue, maxValue - 1);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        [InlineData(420)]
        [InlineData(694561)]
        [InlineData(234324543)]
        [InlineData(1244945695496)]
        public void rnextlongX28longX29_should_generate_number_in_range(long maxValue)
        {
            rnextlong(maxValue).Should().BeInRange(0, maxValue - 1);
        }

        [Theory]
        [InlineData(12, 45)]
        [InlineData(3402, 5205)]
        [InlineData(-400, 400)]
        [InlineData(-53456, 45590)]
        [InlineData(-324504, 3454354)]
        [InlineData(-234545, -345)]
        [InlineData(-3454395943, 4569549694)]
        [InlineData(-214323490, 5645643)]
        [InlineData(23445633455, 345623445644)]
        [InlineData(-253142343142, -456)]
        public void rnextlongX28longX2C_longX29_should_generate_number_in_range(long minValue, long maxValue)
        {
            rnextlong(minValue, maxValue).Should().BeInRange(minValue, maxValue - 1);
        }

        #endregion



        #region .NET Names



        #region Random.Next Explicit Type

        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        [InlineData(420)]
        [InlineData(694561)]
        public void rnextint32X28intX29_should_generate_number_in_range(int maxValue)
        {
            rnextint32(maxValue).Should().BeInRange(0, maxValue - 1);
        }

        [Theory]
        [InlineData(12, 45)]
        [InlineData(3402, 5205)]
        [InlineData(-400, 400)]
        [InlineData(-53456, 45590)]
        [InlineData(-324504, 3454354)]
        [InlineData(-234545, -345)]
        public void rnextint32X28intX2C_intX29_should_generate_number_in_range(int minValue, int maxValue)
        {
            rnextint32(minValue, maxValue).Should().BeInRange(minValue, maxValue - 1);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        [InlineData(420)]
        [InlineData(694561)]
        [InlineData(234324543)]
        [InlineData(1244945695496)]
        public void rnextint64X28longX29_should_generate_number_in_range(long maxValue)
        {
            rnextint64(maxValue).Should().BeInRange(0, maxValue - 1);
        }

        [Theory]
        [InlineData(12, 45)]
        [InlineData(3402, 5205)]
        [InlineData(-400, 400)]
        [InlineData(-53456, 45590)]
        [InlineData(-324504, 3454354)]
        [InlineData(-234545, -345)]
        [InlineData(-3454395943, 4569549694)]
        [InlineData(-214323490, 5645643)]
        [InlineData(23445633455, 345623445644)]
        [InlineData(-253142343142, -456)]
        public void rnextint64X28longX2C_longX29_should_generate_number_in_range(long minValue, long maxValue)
        {
            rnextint64(minValue, maxValue).Should().BeInRange(minValue, maxValue - 1);
        }

        #endregion



        #endregion
    }
}
