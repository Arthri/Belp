using System.Text;

namespace Belp.CodeAnalysis.SourceGenerators.ManifestResourceGenerators;

internal class CodeBuilder
{
    private readonly StringBuilder _builder;

    public int CurrentIndent { get; set; }

    public int IndentSize { get; init; } = 4;

    public string LineEnding { get; init; } = "\r\n";

    public CodeBuilder()
    {
        _builder = new StringBuilder();
    }

    public CodeBuilder(string value)
    {
        _builder = new StringBuilder(value);
    }

    public CodeBuilder(StringBuilder builder)
    {
        _builder = builder;
    }

    public CodeBuilder Indent
    {
        get
        {
            CurrentIndent += IndentSize;
            return this;
        }
    }

    public CodeBuilder Undent
    {
        get
        {
            CurrentIndent -= IndentSize;
            return this;
        }
    }

    public CodeBuilder OpenBrace => AppendLine("{").Indent;

    public CodeBuilder ShutBrace => Undent.AppendLine("}");

    public CodeBuilder Append<T>(T value)
        where T : notnull
    {
        _ = _builder
            .Append(value.ToString())
            ;

        return this;
    }

    public CodeBuilder AppendLine()
    {
        _ = _builder
            .Append(' ', CurrentIndent)
            .Append(LineEnding)
            ;

        return this;
    }

    public CodeBuilder AppendLine(string value)
    {
        _ = _builder
            .Append(' ', CurrentIndent)
            .Append(value)
            .Append(LineEnding)
            ;

        return this;
    }

    public CodeBuilder AppendLine<T>(T value)
        where T : notnull
    {
        _ = _builder
            .Append(' ', CurrentIndent)
            .Append(value.ToString())
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
/// Provides extensions for <see cref="CodeBuilder"/>.
/// </summary>
internal static class IndentedStringBuilderExtensions
{
    public static CodeBuilder Indent(this CodeBuilder builder, int count)
    {
        builder.CurrentIndent += builder.IndentSize * count;
        return builder;
    }

    public static CodeBuilder Undent(this CodeBuilder builder, int count)
    {
        builder.CurrentIndent -= builder.IndentSize * count;
        return builder;
    }

    public static CodeBuilder OpenBrace(this CodeBuilder builder, int count)
    {
        for (int i = 0; i < count; i++)
        {
            _ = builder
                .OpenBrace
                ;
        }

        return builder;
    }

    public static CodeBuilder ShutBrace(this CodeBuilder builder, int count)
    {
        for (int i = 0; i < count; i++)
        {
            _ = builder
                .ShutBrace
                ;
        }

        return builder;
    }
}
