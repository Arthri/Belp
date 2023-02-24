namespace Belp.CodeAnalysis.SourceGenerators.ManifestResourceGenerators;

/// <summary>
/// Provides diagnostic descriptors.
/// </summary>
public static partial class DiagnosticDescriptors
{
    /// <summary>
    /// Provides common diagnostic descriptors for source generators
    /// </summary>
    public static partial class SourceGenerators
    {
        /// <summary>
        /// Provides diagnostics for <see cref="ManifestResourcesGenerator"/>.
        /// </summary>
        public static partial class ManifestResourcesGenerator
        {
            /// <summary>
            /// Represents an error raised when a resource name ends with a period.
            /// </summary>
            public static readonly DiagnosticDescriptor MRGN4002 = new(
                nameof(MRGN4002),
                "Resource name must not end with a period(.)",
                "Remove period at the end of resource name '{0}'",
                DiagnosticCategories.UserError,
                DiagnosticSeverity.Error,
                true
            );

            /// <summary>
            /// Represents an error raised when a resource name has zero length.
            /// </summary>
            public static readonly DiagnosticDescriptor MRGN4003 = new(
                nameof(MRGN4003),
                "Resource name has zero length",
                "Rename resource to a non-zero length",
                DiagnosticCategories.UserError,
                DiagnosticSeverity.Error,
                true
            );

            /// <summary>
            /// Represents an error raised when a resource name does not have an initial namespace.
            /// </summary>
            public static readonly DiagnosticDescriptor MRGN4004 = new(
                nameof(MRGN4004),
                "Resource name does not have initial namespace",
                "Rename resource '{0}' with a initial namespace",
                DiagnosticCategories.UserError,
                DiagnosticSeverity.Error,
                true
            );

            /// <summary>
            /// Represents an error raised when a resource name contains consecutive periods.
            /// </summary>
            public static readonly DiagnosticDescriptor MRGN4005 = new(
                nameof(MRGN4005),
                "Resource name contains empty name",
                "Rename resource '{0}' to turn consecutive periods(..) into one period",
                DiagnosticCategories.UserError,
                DiagnosticSeverity.Error,
                true
            );
        }

        /// <summary>
        /// Represents an error raised when Compilation.AssemblyName was null during source generation.
        /// </summary>
        public static readonly DiagnosticDescriptor MRG4001 = new(
            nameof(MRG4001),
            "Assembly name is null",
            "Compilation.AssemblyName is null or empty during source generation",
            DiagnosticCategories.UserError,
            DiagnosticSeverity.Error,
            true
        );
    }
}
