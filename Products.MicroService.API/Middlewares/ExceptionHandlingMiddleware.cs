namespace Products.MicroService.API.Middlewares;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {

        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            if (ex.InnerException is not null)
            {
                _logger.LogError("{ExceptionType} {Exception Message}", ex.InnerException.GetType().ToString(), ex.InnerException.Message);
            }
            else
            {
                _logger.LogError("{ExceptionType} {Exception Message}", ex.GetType().ToString(), ex.Message);

            }
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(new { Message = ex.Message, Type = ex.GetType().ToString() });
        }
    }
}
    // Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}


