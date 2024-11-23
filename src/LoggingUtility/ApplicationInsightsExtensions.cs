using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggingUtility;

public static class ApplicationInsightsExtensions
{
    public static ILoggingBuilder AddApplicationInsightsLogging(this ILoggingBuilder builder, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.AddApplicationInsights(
            configure =>
            {
                configure.TelemetryChannel.DeveloperMode = true;
                configure.ConnectionString = configuration["ApplicationInsights:ConnectionString"];
            },
            _ => { });

        return builder;
    }

    public static IServiceCollection AddApplicationInsightsTelemetry(this IServiceCollection services, bool isDevelopment)
    {
        services.AddHttpContextAccessor();
        services.AddSingleton<ITelemetryInitializer, TraceEnhancer>();

        services.AddApplicationInsightsTelemetry(options =>
        {
            options.DeveloperMode = isDevelopment;
        });

        return services;
    }
}
