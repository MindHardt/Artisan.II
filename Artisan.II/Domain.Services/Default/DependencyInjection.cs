using Microsoft.Extensions.DependencyInjection;

namespace Artisan.II.Domain.Services.Default;

public static class DependencyInjection
{
    public static IServiceCollection AddDefaultServices(this IServiceCollection services)
    {
        services.Scan(scan =>
        {
            scan.FromAssembliesOf(typeof(DependencyInjection))
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        
        return services;
    }
}