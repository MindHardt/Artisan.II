using Artisan.II.Data.Entities.Arklens.Creatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artisan.II.Data.EFCore.EntityConfigurations;

public class MonsterEntityConfiguration : IEntityTypeConfiguration<Monster>
{
    public void Configure(EntityTypeBuilder<Monster> builder)
    {
        builder.Property(x => x.Type)
            .HasConversion<string>();
    }
}