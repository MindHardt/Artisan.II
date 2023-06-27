namespace Artisan.II.Server.Middlewares;

public static class DependencyInjection
{
    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app) 
        => app.UseMiddleware<ErrorHandlingMiddleware>();

    public static IServiceCollection AddErrorHandling(this IServiceCollection services) 
        => services.AddScoped<ErrorHandlingMiddleware>();
}