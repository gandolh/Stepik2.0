using Microsoft.Extensions.Logging;

namespace Licenta.SDK.Logging.File
{
    public sealed class FileLogger : ILogger
    {
        private readonly string _name;
        private readonly Func<FileLoggerConfiguration> _getCurrentConfig;

        public FileLogger(
            string name,
            Func<FileLoggerConfiguration> getCurrentConfig
            ) =>
            (_name, _getCurrentConfig) = (name, getCurrentConfig);

        //
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default!;

        //TODO: check minimum loglevel probably
        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            FileLoggerConfiguration config = _getCurrentConfig();
            if (config.EventId == 0 || config.EventId == eventId.Id)
            {
                string formattedLog = "";
                formattedLog += $"[{eventId.Id,2}: {logLevel,-12}]" + Environment.NewLine;
                formattedLog += $"     {_name} - " + Environment.NewLine;
                formattedLog += $"{formatter(state, exception)}" + Environment.NewLine;
                formattedLog += Environment.NewLine;
                System.IO.File.AppendAllText(config.Path, formattedLog);

            }
        }
    }
}
