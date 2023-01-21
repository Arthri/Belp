namespace Belp.Tests.Extensions;

/// <summary>
/// Provides extension methods for all types.
/// </summary>
internal static class AllExtensions
{
    /// <summary>
    /// Wraps the specified element in a singleton enumerable.
    /// </summary>
    /// <typeparam name="T">The type of objects to enumerate.</typeparam>
    /// <param name="element">The element to iterate over.</param>
    /// <returns>A singleton enumerable iterating over the specified member.</returns>
    public static SingletonEnumerable<T> AsSingletonEnumerable<T>(this T element)
    {
        return new SingletonEnumerable<T>(element);
    }
}
