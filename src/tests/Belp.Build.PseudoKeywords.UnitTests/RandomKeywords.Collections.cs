namespace Belp.Build.PseudoKeywords.UnitTests;

public partial class RandomKeywords
{
    public partial class Collections
    {
        public static readonly IEnumerable<object?[]> Data_DefaultCollections = new object?[][]
        {
            new object?[] { new int[] { 1, 2, 3, 4 } },
            new object?[] { new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k" } },
            new object?[] { new object[] { 1, "f", 4, 'c', 53, 32, "r" } },
        };

        #region Explicit Functions - Index

        [Theory]
        [MemberData(nameof(Data_DefaultCollections))]
        public void rnextindexX28ICollectionX29_should_generate_index_in_collection(ICollection collection)
        {
            rnextindex(collection).Should().BeInRange(0, collection.Count - 1);
        }

        [Theory]
        [MemberData(nameof(Data_DefaultCollections))]
        public void rnextindexoX28IListX2C_out_objectX29_should_generate_index_in_list(IList list)
        {
            rnextindexo(list, out _).Should().BeInRange(0, list.Count - 1);
        }

        [Theory]
        [MemberData(nameof(Data_DefaultCollections))]
        public void rnextindexoX28IListX2C_out_objectX29_out_object_should_be_in_list(IList list)
        {
            _ = rnextindexo(list, out object? element);
            list.Should().Match(l => ((IList)l).Contains(element), "{0} should contain {1} '{2}'", nameof(list), nameof(element), element);
        }

        #endregion



        #region Explicit Functions - Element

        [Theory]
        [MemberData(nameof(Data_DefaultCollections))]
        public void rnextelementoX28IListX29_should_be_in_list(IList list)
        {
            object? element = rnextelemento(list);
            list.Should().Match(l => ((IList)l).Contains(element), "{0} should contain {1} '{2}'", nameof(list), nameof(element), element);
        }

        [Theory]
        [MemberData(nameof(Data_DefaultCollections))]
        public void rnextelementX3CTX3EX28IListX3CTX3EX29_should_be_in_list<T>(IList<T> list)
        {
            list.Should().Contain(rnextelement(list));
        }

        [Theory]
        [MemberData(nameof(Data_DefaultCollections))]
        public void rnextelementoX28IListX2CX20outX20intX29_should_be_in_list(IList list)
        {
            object? element = rnextelemento(list, out _);
            list.Should().Match(l => ((IList)l).Contains(element), "{0} should contain {1} '{2}'", nameof(list), nameof(element), element);
        }

        [Theory]
        [MemberData(nameof(Data_DefaultCollections))]
        public void rnextelementoX28IListX2CX20outX20intX29_should_generate_index_in_list(IList list)
        {
            _ = rnextelemento(list, out int index);
            index.Should().BeInRange(0, list.Count - 1);
        }

        [Theory]
        [MemberData(nameof(Data_DefaultCollections))]
        public void rnextelementX3CTX3EX28IListX3CTX3EX2CX20outX20intX29_should_be_in_list<T>(IList<T> list)
        {
            list.Should().Contain(rnextelement(list, out _));
        }

        [Theory]
        [MemberData(nameof(Data_DefaultCollections))]
        public void rnextelementX3CTX3EX28IListX3CTX3EX2CX20outX20intX29_should_generate_index_in_list<T>(IList<T> list)
        {
            _ = rnextelement(list, out int index);
            index.Should().BeInRange(0, list.Count - 1);
        }

        #endregion
    }
}
