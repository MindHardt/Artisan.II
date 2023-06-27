namespace Artisan.II.Data.Entities.Arklens.Creatures;

public record Character : Creature
{
    public override CreatureType CreatureType => CreatureType.Person;
}