using Microsoft.Extensions.DependencyInjection;

namespace Artisan.II.Client.Common.JsInterop.Default;

public static class DependencyInjection
{
    public static IServiceCollection AddJsInterop(this IServiceCollection services)
    {
        services.Scan(scan =>
        {
            scan.FromAssemblyDependencies(typeof(DependencyInjection).Assembly)
                .AddClasses(c => c.AssignableTo<JsInteropBase>())
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        return services;
    }
}