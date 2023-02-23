using Microsoft.Build.Framework;
using Xunit.Abstractions;

namespace Belp.Tests.MSBuild.xUnit;

public class XUnitMSBuildLoggerAdapter : ITestOutputHelper, ILogger
{
    private readonly ITestOutputHelper _output;

    string? ILogger.Parameters
    {
        get => null;

        set
        {
        }
    }

    /// <inheritdoc />
    public LoggerVerbosity Verbosity { get; set; } = LoggerVerbosity.Normal;

    public XUnitMSBuildLoggerAdapter(ITestOutputHelper output)
    {
        _output = output;
    }

    #region ILogger

    void ILogger.Initialize(IEventSource eventSource)
    {
        eventSource.BuildFinished += (sender, e) => WriteLine(e.Message);
        eventSource.BuildStarted += (sender, e) => WriteLine(e.Message);
        eventSource.ErrorRaised += (sender, e) => WriteLine($"ERR {e.Code}: {e.Message}");
        eventSource.MessageRaised += (sender, e) =>
        {
            if (e.Importance == MessageImportance.High)
            {
                WriteLine(e.Message);
            }
        };
        eventSource.ProjectFinished += (sender, e) => WriteLine(e.Message);
        eventSource.ProjectStarted += (sender, e) => WriteLine(e.Message);
        eventSource.WarningRaised += (sender, e) => WriteLine($"WRN {e.Code}: {e.Message}");
    }

    void ILogger.Shutdown()
    {
    }

    #endregion

    /// <inheritdoc />
    public void WriteLine(string message)
    {
        _output.WriteLine(message);
    }

    /// <inheritdoc />
    public void WriteLine(string format, params object[] args)
    {
        _output.WriteLine(format, args);
    }
}
