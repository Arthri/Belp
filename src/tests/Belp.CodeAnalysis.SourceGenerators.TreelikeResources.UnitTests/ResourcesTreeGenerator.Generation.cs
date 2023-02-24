using SGTest = Belp.Tests.CodeAnalysis.SourceGenerators.CSharpIncrementalSourceGeneratorVerifier<Belp.CodeAnalysis.SourceGenerators.TreelikeResources.ResourcesTreeGenerator>.Test;

namespace Belp.CodeAnalysis.SourceGenerators.TreelikeResources.UnitTests;

public partial class ResourcesTreeGenerator
{
    public partial class Generation
    {
        // This class isn't essential, because it's used for changing the test display name
        // without it, the test would display the contents of all files used in the test
        public class TestData
        {
            public required string TestName { get; init; }
            public required string EditorConfig { get; init; }
            public required IEnumerable<(string filename, SourceText content)> Inputs { get; init; }
            public required IEnumerable<(Type sourceGeneratorType, string filename, SourceText content)> Outputs { get; init; }

            /// <inheritdoc />
            public override string ToString()
            {
                return TestName;
            }
        }

        private class TestDataGenerator : IEnumerable<object?[]>
        {
            public IEnumerator<object?[]> GetEnumerator()
            {
                string testsPath = Path.Combine(Resources.Path, "ResourcesTreeGenerator", "Generation");
                string[] tests = Directory.GetDirectories(testsPath);

                foreach (string test in tests)
                {
                    string testName = Path.GetFileName(test);
                    string editorconfig = File.ReadAllText(Path.Combine(test, ".editorconfig"));

                    string inputsPath = Path.Combine(test, "Inputs");
                    string[] inputs = Directory.GetFiles(inputsPath, "*", SearchOption.AllDirectories);

                    string outputsPath = Path.Combine(test, "Outputs");
                    string[] outputs = Directory.GetFiles(outputsPath, "*", SearchOption.AllDirectories);

                    yield return new object?[]
                    {
                        new TestData
                        {
                            TestName = testName,
                            EditorConfig = editorconfig,
                            Inputs = inputs.Select(f => (
                                f[inputsPath.Length..].Replace('\\', '/'),
                                SourceText.From(File.ReadAllText(f), Encoding.UTF8)
                            )),
                            Outputs = outputs.Select(f => (
                                typeof(TreelikeResources.ResourcesTreeGenerator),
                                f[(outputsPath.Length + 1)..],
                                SourceText.From(File.ReadAllText(f), Encoding.UTF8)
                            )),
                        }
                    };
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public Task Given_a_set_of_filesX2C_generate_correct_structure(TestData data)
        {
            var test = SGTest.From(data.TestName);

            test.TestState.AnalyzerConfigFiles.Add(("/.editorconfig", data.EditorConfig));

            test.TestState.AdditionalFiles.AddRange(data.Inputs);

            foreach ((Type sourceGeneratorType, string filename, SourceText content) output in data.Outputs)
            {
                test.TestState.GeneratedSources.Add(output);
            }

            return test.RunAsync();
        }
    }
}
