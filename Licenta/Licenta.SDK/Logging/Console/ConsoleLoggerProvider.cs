﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Runtime.Versioning;

namespace Licenta.SDK.Logging.Console
{
    [UnsupportedOSPlatform("browser")]
    [ProviderAlias("ColorConsole")]
    public sealed class ConsoleLoggerProvider : ILoggerProvider
    {
        private readonly IDisposable? _onChangeToken;
        private ConsoleLoggerConfiguration _currentConfig;
        private readonly ConcurrentDictionary<string, ConsoleLogger> _loggers =
            new(StringComparer.OrdinalIgnoreCase);

        public ConsoleLoggerProvider(
            IOptionsMonitor<ConsoleLoggerConfiguration> config)
        {
            _currentConfig = config.CurrentValue;
            _onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
        }

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => new ConsoleLogger(name, GetCurrentConfig));

        private ConsoleLoggerConfiguration GetCurrentConfig() => _currentConfig;

        public void Dispose()
        {
            _loggers.Clear();
            _onChangeToken?.Dispose();
        }
    }
}
