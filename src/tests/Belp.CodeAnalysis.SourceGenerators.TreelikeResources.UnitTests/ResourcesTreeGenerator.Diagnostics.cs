﻿using SGTest = Belp.Tests.CodeAnalysis.SourceGenerators.CSharpIncrementalSourceGeneratorVerifier<Belp.CodeAnalysis.SourceGenerators.TreelikeResources.ResourcesTreeGenerator>.Test;

namespace Belp.CodeAnalysis.SourceGenerators.TreelikeResources.UnitTests;

public partial class ResourcesTreeGenerator
{
    public partial class Diagnostics
    {
        [Fact]
        public Task When_AssemblyName_eq_nullX2C_expect_CS8203_and_MRG4001()
        {
            var test = SGTest.From("", () => new()
            {
                TestState =
                {
                    ExpectedDiagnostics =
                    {
                        DiagnosticResult.CompilerError("CS8203"),
                        new DiagnosticResult(DiagnosticDescriptors.SourceGenerators.MRG4001),
                    },
                },
            });

            return test.RunAsync();
        }

        [Fact]
        public Task When_ResourceName_ends_with_X22X2EX22X2C_expect_MRGN4002()
        {
            var test = new SGTest
            {
                TestState =
                {
                    AdditionalFiles =
                    {
                        ("/File.txt.", ""),
                    },
                    AnalyzerConfigFiles =
                    {
                        (
                            "/.editorconfig",
                            """
                            [/File.txt.]
                            build_metadata.AdditionalFiles.ManifestResourceName = File.txt.
                            build_metadata.AdditionalFiles.TargetSourceGenerator = Belp.CodeAnalysis.SourceGenerators.TreelikeResources.ResourcesTreeGenerator
                            """
                        ),
                    },

                    ExpectedDiagnostics =
                    {
                        new DiagnosticResult(DiagnosticDescriptors.SourceGenerators.ResourcesTreeGenerator.MRGN4002),
                    },
                },
            };

            return test.RunAsync();
        }

        [Fact]
        public Task When_ResourceName_is_emptyX2C_expect_MRGN4003()
        {
            var test = new SGTest
            {
                TestState =
                {
                    AdditionalFiles =
                    {
                        ("/File.txt", ""),
                    },
                    AnalyzerConfigFiles =
                    {
                        (
                            "/.editorconfig",
                            """
                            [/File.txt]
                            build_metadata.AdditionalFiles.ManifestResourceName =
                            build_metadata.AdditionalFiles.TargetSourceGenerator = Belp.CodeAnalysis.SourceGenerators.TreelikeResources.ResourcesTreeGenerator
                            """
                        ),
                    },

                    ExpectedDiagnostics =
                    {
                        new DiagnosticResult(DiagnosticDescriptors.SourceGenerators.ResourcesTreeGenerator.MRGN4003),
                    },
                },
            };

            return test.RunAsync();
        }

        [Fact]
        public Task When_ResourceName_does_not_contain_X22X2EX22X2C_expect_MRGN4004()
        {
            var test = new SGTest
            {
                TestState =
                {
                    AdditionalFiles =
                    {
                        ("/File", ""),
                    },
                    AnalyzerConfigFiles =
                    {
                        (
                            "/.editorconfig",
                            """
                            [/File]
                            build_metadata.AdditionalFiles.ManifestResourceName = File
                            build_metadata.AdditionalFiles.TargetSourceGenerator = Belp.CodeAnalysis.SourceGenerators.TreelikeResources.ResourcesTreeGenerator
                            """
                        ),
                    },

                    ExpectedDiagnostics =
                    {
                        new DiagnosticResult(DiagnosticDescriptors.SourceGenerators.ResourcesTreeGenerator.MRGN4004),
                    },
                },
            };

            return test.RunAsync();
        }

        [Fact]
        public Task When_ResourceName_contains_X22X2EX2EX22X2C_expect_MRGN4005()
        {
            var test = new SGTest
            {
                TestState =
                {
                    AdditionalFiles =
                    {
                        ("/File..txt", ""),
                    },
                    AnalyzerConfigFiles =
                    {
                        (
                            "/.editorconfig",
                            """
                            [/File..txt]
                            build_metadata.AdditionalFiles.ManifestResourceName = File..txt
                            build_metadata.AdditionalFiles.TargetSourceGenerator = Belp.CodeAnalysis.SourceGenerators.TreelikeResources.ResourcesTreeGenerator
                            """
                        ),
                    },

                    ExpectedDiagnostics =
                    {
                        new DiagnosticResult(DiagnosticDescriptors.SourceGenerators.ResourcesTreeGenerator.MRGN4005),
                    },
                },
            };

            return test.RunAsync();
        }
    }
}
