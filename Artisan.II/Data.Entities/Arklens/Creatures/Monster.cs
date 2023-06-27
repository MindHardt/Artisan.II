namespace Artisan.II.Data.Entities.Arklens.Creatures;

public record Monster : Creature
{
    public override CreatureType CreatureType => Type;
    public required CreatureType Type { get; set; }
}