using Artisan.II.Data.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Artisan.II.Data.EFCore;

public static class DependencyInjection
{
    public static IServiceCollection AddEfCoreRepositories<TContext>(this IServiceCollection services)
        where TContext : DbContext
    {
        services.AddScoped<DbContext, TContext>();
        
        services.Scan(scan =>
        {
            scan.FromAssemblies(typeof(DependencyInjection).Assembly)
                .AddClasses(c => c.AssignableTo(typeof(EfCoreRepositoryBase<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        
        return services;
    }
}