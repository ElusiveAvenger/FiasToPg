using System;
using FiasToPg.Settings;
using Microsoft.Extensions.Logging;

namespace FiasToPg.Logging
{
    public class ConsoleLogger<T> : ILogger<T>
    {
        private readonly string _loggerName;

        private readonly CommonSettings _settings;

        public ConsoleLogger(CommonSettings settings)
        {
            _settings = settings;
            _loggerName = typeof(T).FullName;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{logLevel}|{_loggerName}] {formatter.Invoke(state, exception)}");
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= _settings.LogLevel;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }
    }
}
