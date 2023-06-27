namespace Artisan.II.Data.Entities.Arklens.Creatures;

public abstract record Creature
{
    public required string Name { get; set; }
    public abstract CreatureType CreatureType { get; }
    public required int DangerLevel { get; set; }
    public required int Health { get; set; }
}