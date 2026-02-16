namespace Chirper.Common.Api.Middleware;

/// <summary>
/// Middleware that adds correlation ID tracking to requests for distributed tracing.
/// </summary>
public class CorrelationIdMiddleware
{
    private const string CorrelationIdHeaderName = "X-Correlation-ID";
    private readonly RequestDelegate _next;
    private readonly ILogger<CorrelationIdMiddleware> _logger;

    public CorrelationIdMiddleware(RequestDelegate next, ILogger<CorrelationIdMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Try to get correlation ID from request header
        var correlationId = context.Request.Headers[CorrelationIdHeaderName].FirstOrDefault();

        // If not present, generate a new one
        if (string.IsNullOrWhiteSpace(correlationId))
        {
            correlationId = Guid.NewGuid().ToString();
            _logger.LogDebug("Generated new correlation ID: {CorrelationId}", correlationId);
        }
        else
        {
            _logger.LogDebug("Using correlation ID from request: {CorrelationId}", correlationId);
        }

        // Add correlation ID to response header so client can track it
        context.Response.Headers[CorrelationIdHeaderName] = correlationId;

        // Store in HttpContext items for access throughout the request pipeline
        context.Items["CorrelationId"] = correlationId;

        // Enrich Serilog logs with correlation ID using LogContext
        using (Serilog.Context.LogContext.PushProperty("CorrelationId", correlationId))
        {
            await _next(context);
        }
    }
}

/// <summary>
/// Extension methods for registering the correlation ID middleware.
/// </summary>
public static class CorrelationIdMiddlewareExtensions
{
    /// <summary>
    /// Adds correlation ID middleware to the application pipeline.
    /// Should be added early in the pipeline to ensure all logs are enriched.
    /// </summary>
    public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder app)
    {
        return app.UseMiddleware<CorrelationIdMiddleware>();
    }
}
