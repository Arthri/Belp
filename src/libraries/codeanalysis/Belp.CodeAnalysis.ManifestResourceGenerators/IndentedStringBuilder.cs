using System.Text;

namespace Belp.CodeAnalysis.ManifestResourceGenerators;

internal ref struct IndentedStringBuilder
{
    private readonly StringBuilder _builder;

    public StringBuilder Builder => _builder;

    private int _currentIndent;

    public int CurrentIndent
    {
        get => _currentIndent;

        set => _currentIndent = value;
    }

    public IndentedStringBuilder(StringBuilder builder, int currentIndent = 0)
    {
        _builder = builder;
        _currentIndent = currentIndent;
    }

    /// <inheritdoc cref="StringBuilder.AppendLine()" />
    public IndentedStringBuilder AppendLine()
    {
        _ = _builder
            .Append(' ', _currentIndent)
            .AppendLine()
            ;

        return this;
    }

    /// <inheritdoc cref="StringBuilder.AppendLine(string)" />
    public IndentedStringBuilder AppendLine(string value)
    {
        _ = _builder
            .Append(' ', _currentIndent)
            .AppendLine(value)
            ;

        return this;
    }

    /// <inheritdoc cref="StringBuilder.ToString()" />
    public override string ToString()
    {
        return _builder.ToString();
    }
}
