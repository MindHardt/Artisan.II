using Artisan.II.Data.Entities.Arklens;
using Artisan.II.Data.Entities.Arklens.Creatures;

namespace Artisan.II.Data.Abstractions;

public interface ICreatureRepository
{
    /// <summary>
    /// Gets a <see cref="Creature"/> whose name is equal to
    /// <see cref="name"/> or <see langword="null"/> if none is found.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public ValueTask<Creature?> GetByName(string name);
    
    /// <summary>
    /// Saves <paramref name="creature"/> to the storage.
    /// </summary>
    /// <param name="creature"></param>
    /// <returns></returns>
    public ValueTask<Creature> Save(Creature creature);
}