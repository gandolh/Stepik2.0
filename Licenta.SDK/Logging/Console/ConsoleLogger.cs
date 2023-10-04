using Microsoft.Extensions.Logging;

namespace Licenta.SDK.Logging.Console
{
    public sealed class ConsoleLogger : ILogger
    {
        private readonly string _name;
        private readonly Func<ConsoleLoggerConfiguration> _getCurrentConfig;

        public ConsoleLogger(
            string name,
            Func<ConsoleLoggerConfiguration> getCurrentConfig) =>
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

            ConsoleLoggerConfiguration config = _getCurrentConfig();
            if (config.EventId == 0 || config.EventId == eventId.Id)
            {
                System.Console.WriteLine($"[{eventId.Id,2}: {logLevel,-12}]");
                System.Console.Write($"     {_name} - ");
                System.Console.Write($"{formatter(state, exception)}");
                System.Console.WriteLine();
            }
        }
    }
}
