namespace CleanArchitecture.WebApi.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder CreateBuilder(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        return app;
    }
}
