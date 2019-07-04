using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FiasToPg.Logging
{
    public static class Extension
    {
        public static ILoggingBuilder AddConsoleLogger(this ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.Services.AddTransient(typeof(ILogger<>), typeof(ConsoleLogger<>));

            return loggingBuilder;
        }
    }
}
