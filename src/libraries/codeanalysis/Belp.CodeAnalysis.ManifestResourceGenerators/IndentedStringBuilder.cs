using System.Text;

namespace Belp.CodeAnalysis.ManifestResourceGenerators;

internal ref struct IndentedStringBuilder
{
    private readonly StringBuilder _builder;

    public int CurrentIndent { get; set; }

    public int IndentSize { get; init; } = 4;

    public string LineEnding { get; init; } = "\r\n";

    public IndentedStringBuilder()
    {
        _builder = new StringBuilder();
    }

    public IndentedStringBuilder(string value)
    {
        _builder = new StringBuilder(value);
    }

    public IndentedStringBuilder(StringBuilder builder)
    {
        _builder = builder;
    }

    public IndentedStringBuilder Indent
    {
        get
        {
            CurrentIndent += IndentSize;
            return this;
        }
    }

    public IndentedStringBuilder Undent
    {
        get
        {
            CurrentIndent -= IndentSize;
            return this;
        }
    }

    public IndentedStringBuilder AppendLine()
    {
        _ = _builder
            .Append(' ', CurrentIndent)
            .Append(LineEnding)
            ;

        return this;
    }

    public IndentedStringBuilder AppendLine(string value)
    {
        _ = _builder
            .Append(' ', CurrentIndent)
            .AppendLine(value)
            .Append(LineEnding)
            ;

        return this;
    }

    public IndentedStringBuilder AppendLine<T>(T value)
        where T : notnull
    {
        _ = _builder
            .Append(' ', CurrentIndent)
            .AppendLine(value.ToString())
            .Append(LineEnding)
            ;

        return this;
    }

    /// <inheritdoc cref="StringBuilder.ToString()" />
    public override string ToString()
    {
        return _builder.ToString();
    }
}

/// <summary>
/// Provides extensions for <see cref="IndentedStringBuilder"/>.
/// </summary>
internal static class IndentedStringBuilderExtensions
{
    public static IndentedStringBuilder Indent(this IndentedStringBuilder builder, int count)
    {
        builder.CurrentIndent += builder.IndentSize * count;
        return builder;
    }

    public static IndentedStringBuilder Undent(this IndentedStringBuilder builder, int count)
    {
        builder.CurrentIndent -= builder.IndentSize * count;
        return builder;
    }
}
