﻿using SGTest = Belp.Tests.CodeAnalysis.SourceGenerators.CSharpIncrementalSourceGeneratorVerifier<Belp.CodeAnalysis.ManifestResourceGenerators.ManifestResourcesHelperGenerator>.Test;

namespace Belp.CodeAnalysis.ManifestResourceGenerators.UnitTests;

public partial class ManifestResourcesHelperGenerator
{
    public partial class Generation
    {
        [Fact]
        public Task Generates_ManifestResourcesHelper()
        {
            var test = new SGTest
            {
                TestState =
                {
                    GeneratedSources =
                    {
                        (
                            typeof(ManifestResourceGenerators.ManifestResourcesHelperGenerator),
                            "ManifestResourcesHelper.cs",
                            """
                            // <auto-generated/>
                            #pragma warning disable
                            #nullable disable

                            /// <summary>
                            /// Provides constants and methods to access manifest resources.
                            /// </summary>
                            static partial class ManifestResourcesHelper
                            {
                                private static readonly global::System.Reflection.Assembly _assembly = typeof(ManifestResourcesHelper).Assembly;

                                /// <summary>
                                /// Gets a stream to the resource with the specified name.
                                /// </summary>
                                /// <param name="resourceName">The resource's name.</param>
                                /// <returns>A stream to the resource with the specified name if the resource exists; otherwise, <see langword="null"/>.</returns>
                                public static global::System.IO.Stream? GetStream(string resourceName)
                                {
                                    return _assembly.GetManifestResourceStream(resourceName);
                                }

                                /// <summary>
                                /// Gets the resource with the specified name and turns it into a string.
                                /// </summary>
                                /// <param name="resourceName">The resource's name.</param>
                                /// <returns>The resource with the specified name as a string if the resource exists; otherwise, <see langword="null"/>.</returns>
                                public static string? GetString(string resourceName)
                                {
                                    using (global::System.IO.Stream? stream = _assembly.GetManifestResourceStream(resourceName))
                                    {
                                        if (ReferenceEquals(stream, null))
                                        {
                                            return null;
                                        }

                                        using (global::System.IO.StreamReader reader = new global::System.IO.StreamReader(stream))
                                        {
                                            return reader.ReadToEnd();
                                        }
                                    }
                                }
                            }
            
                            """
                        ),
                    },
                },
            };

            return test.RunAsync();
        }
    }
}
