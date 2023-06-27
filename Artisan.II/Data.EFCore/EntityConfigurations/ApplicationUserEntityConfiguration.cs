using Artisan.II.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artisan.II.Data.EFCore.EntityConfigurations;

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasOne(x => x.Avatar)
            .WithMany()
            .HasForeignKey(x => x.AvatarName)
            .OnDelete(DeleteBehavior.SetNull);
    }
}