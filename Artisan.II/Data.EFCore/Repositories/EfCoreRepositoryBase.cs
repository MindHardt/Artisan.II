using Microsoft.EntityFrameworkCore;

namespace Artisan.II.Data.EFCore.Repositories;

public abstract class EfCoreRepositoryBase<T>
    where T : class
{
    private readonly DbContext _ctx;

    protected EfCoreRepositoryBase(DbContext ctx)
    {
        _ctx = ctx;
    }
    
    /// <summary>
    /// The <see cref="DbSet{TEntity}"/> used for accessing the table.
    /// </summary>
    protected DbSet<T> Set => _ctx.Set<T>();
    /// <summary>
    /// Saves changes made in this <see cref="EfCoreRepositoryBase{T}"/>.
    /// </summary>
    /// <returns></returns>
    protected Task CommitAsync() => _ctx.SaveChangesAsync();

}