using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LoggingUtility;

public static class ApplicationInsightsExtensions
{
    public static ILoggingBuilder AddApplicationInsightsLogging(this ILoggingBuilder builder, IConfiguration configuration)
    {
        builder.AddApplicationInsights(
            configure =>
            {
                configure.TelemetryChannel.DeveloperMode = true;
                configure.ConnectionString = configuration["ApplicationInsights:ConnectionString"];
            },
            _ => { });

        return builder;
    }
}
