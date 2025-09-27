using System;
using Microsoft.AspNetCore.Builder;

namespace Tawla._360.Logging.Middlewares;

public static class LoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseLoggingMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<CorrelationIdMiddleware>();
        app.UseMiddleware<RequestResponseLoggingMiddleware>();
        return app;
    }
}
