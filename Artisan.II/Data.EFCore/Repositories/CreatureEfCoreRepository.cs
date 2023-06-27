using Artisan.II.Data.Abstractions;
using Artisan.II.Data.Entities.Arklens;
using Artisan.II.Data.Entities.Arklens.Creatures;
using Microsoft.EntityFrameworkCore;

namespace Artisan.II.Data.EFCore.Repositories;

public class CreatureEfCoreRepository:
    EfCoreRepositoryBase<Creature>,
    ICreatureRepository
{
    public CreatureEfCoreRepository(DbContext ctx) : base(ctx)
    { }

    public async ValueTask<Creature?> GetByName(string name)
    {
        return await Set
            .Where(x => x.Name == name)
            .FirstOrDefaultAsync();
    }

    public async ValueTask<Creature> Save(Creature creature)
    {
        var entry = await NameExists(creature.Name) ? 
            Set.Add(creature) : 
            Set.Update(creature);
        
        await CommitAsync();
        return entry.Entity;
    }

    private async ValueTask<bool> NameExists(string name) => await Set.AnyAsync(x => x.Name == name);
}