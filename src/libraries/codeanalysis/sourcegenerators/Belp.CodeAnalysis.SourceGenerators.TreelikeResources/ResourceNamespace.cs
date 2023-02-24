namespace Belp.CodeAnalysis.SourceGenerators.TreelikeResources;

/// <summary>
/// Represents collected resources under a namespace.
/// </summary>
/// <param name="Namespace">The collected resources' namespace.</param>
/// <param name="Resources">The collected resources.</param>
internal record struct ResourceNamespace(string Namespace, EquatableReadOnlyList<string> Resources)
{
}
