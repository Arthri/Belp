namespace Belp.CodeAnalysis.SourceGenerators.ManifestResourceGenerators.Extensions;

/// <summary>
/// Provides extensions for <see cref="KeyValuePair{TKey, TValue}"/>.
/// </summary>
internal static class KeyValuePairExtensions
{
    /// <summary>
    /// Deconstructs the specified key value pair.
    /// </summary>
    /// <typeparam name="TKey"><inheritdoc cref="KeyValuePair{TKey, TValue}" path="/typeparam[@name='TKey']" /></typeparam>
    /// <typeparam name="TValue"><inheritdoc cref="KeyValuePair{TKey, TValue}" path="/typeparam[@name='TValue']" /></typeparam>
    /// <param name="kvp">The key value pair to deconstruct.</param>
    /// <param name="key">The key of the key value pair.</param>
    /// <param name="value">The value of the key value pair.</param>
    public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> kvp, out TKey key, out TValue value)
    {
        key = kvp.Key;
        value = kvp.Value;
    }
}
