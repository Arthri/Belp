using Belp.Tests.Common;

/// <summary>
/// Globally provides extensions to all types.
/// </summary>
#pragma warning disable CA1050 // Declare types in namespaces
public static class GlobalAllExtensions
#pragma warning restore CA1050 // Declare types in namespaces
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
