using Microsoft.ApplicationInsights.AspNetCore.TelemetryInitializers;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace LoggingUtility;

public class TraceEnhancer(IHttpContextAccessor httpContextAccessor, IHostEnvironment env) : TelemetryInitializerBase(httpContextAccessor)
{
    protected override void OnInitializeTelemetry(HttpContext platformContext, RequestTelemetry requestTelemetry, ITelemetry telemetry)
    {
        if (telemetry is ISupportProperties supportProperties)
        {
            supportProperties.Properties[nameof(IHostEnvironment.EnvironmentName)] = env.EnvironmentName;
            supportProperties.Properties[nameof(IHostEnvironment.ApplicationName)] = env.ApplicationName;
        }
    }
}
