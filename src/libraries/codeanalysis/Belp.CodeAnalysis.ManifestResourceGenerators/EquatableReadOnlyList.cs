using System.Collections;

namespace ManifestResourceGenerators;

/// <summary>
/// Wraps a specified list for better equality checks.
/// </summary>
/// <typeparam name="T">The type of element in the list.</typeparam>
internal readonly struct EquatableReadOnlyList<T> :
    IEquatable<EquatableReadOnlyList<T>>,
    IEquatable<IReadOnlyList<T>>,
    IReadOnlyList<T>
{
    private readonly IReadOnlyList<T> _list;

    /// <summary>
    /// Gets the backing list.
    /// </summary>
    public IReadOnlyList<T> BackingList => _list;

    /// <summary>
    /// Initializes a new instance of <see cref="EquatableReadOnlyList{T}" /> for the specified <paramref name="list"/>.
    /// </summary>
    /// <param name="list">The list to wrap.</param>
    public EquatableReadOnlyList(IReadOnlyList<T> list)
    {
        _list = list;
    }

    /// <inheritdoc />
    public T this[int index] => _list[index];

    /// <inheritdoc />
    public int Count => _list.Count;

    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        return obj is EquatableReadOnlyList<T> other && Equals(other);
    }

    /// <inheritdoc />
    public bool Equals(EquatableReadOnlyList<T> other)
    {
        return Equals(other._list);
    }

    /// <inheritdoc />
    public bool Equals(IReadOnlyList<T> otherList)
    {
        if (_list.Count != otherList.Count)
        {
            return false;
        }

        IEnumerator<T> enumerator = _list.GetEnumerator();

        foreach (T otherElement in otherList)
        {
            if (!enumerator.MoveNext())
            {
                return false;
            }

            T? current = enumerator.Current;
            if (!ReferenceEquals(current, otherElement))
            {
                if (current is null || otherElement is null || !current.Equals(otherElement))
                {
                    return false;
                }
            }
        }

        return true;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        foreach (T element in _list)
        {
            hashCode.Add(element);
        }

        return hashCode.ToHashCode();
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return _list.ToString();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }
}
