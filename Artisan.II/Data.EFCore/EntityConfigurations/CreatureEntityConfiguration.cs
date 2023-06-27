using Artisan.II.Data.Entities.Arklens.Creatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artisan.II.Data.EFCore.EntityConfigurations;

public class CreatureEntityConfiguration : IEntityTypeConfiguration<Creature>
{
    public void Configure(EntityTypeBuilder<Creature> builder)
    {
        builder.ToTable("Creatures");
        builder.HasKey(x => x.Name);

        builder.HasDiscriminator()
            .HasValue<Monster>(nameof(Monster))
            .HasValue<Character>(nameof(Character));
    }
}