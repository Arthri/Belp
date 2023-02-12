using System.Collections;

namespace Belp.Tests.CodeAnalysis.SourceGenerators;

/// <summary>
/// Supports a simple iteration over a collection of one element.
/// </summary>
/// <typeparam name="T">The type of objects to enumerate.</typeparam>
internal sealed class SingletonEnumerable<T> : IEnumerable<T>
{
    /// <summary>
    /// Supports a simple iteration over one element.
    /// </summary>
    public sealed class Enumerator : IEnumerator<T>
    {
        private readonly T _element;
        private int _state;

        /// <summary>
        /// Initializes a new instance of <see cref="Enumerable"/> for the specified element.
        /// </summary>
        /// <param name="element">The element to iterate over.</param>
        public Enumerator(T element)
        {
            _element = element;
        }

        /// <summary>
        /// Gets the one element being iterated over.
        /// </summary>
        public T Element => _element;

        /// <inheritdoc />
        public T Current => _state switch
        {
            0 => throw new InvalidOperationException("Enumeration has not started. Call MoveNext."),
            1 => _element,
            2 => throw new InvalidOperationException("Enumeration already finished."),
            _ => throw new InvalidOperationException("Invalid state."),
        };

        object IEnumerator.Current => Current!;

        /// <inheritdoc />
        public void Dispose()
        {
        }

        /// <inheritdoc />
        public bool MoveNext()
        {
            if (_state == 0)
            {
                _state = 1;

                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public void Reset()
        {
            _state = 0;
        }
    }

    private readonly T _element;

    /// <summary>
    /// Initializes a new instance of <see cref="SingletonEnumerable{T}"/> for the specified element.
    /// </summary>
    /// <param name="element">The element to iterate over.</param>
    public SingletonEnumerable(T element)
    {
        _element = element;
    }

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(_element);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new Enumerator(_element);
    }
}
