using Artisan.II.Data.Entities.UserFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Artisan.II.Data.EFCore.EntityConfigurations;

public class UserFileEntityConfiguration : IEntityTypeConfiguration<UserFile>
{
    public void Configure(EntityTypeBuilder<UserFile> builder)
    {
        builder.ToTable("UserFiles");
        builder.HasKey(x => x.Name);
        
        builder.Property(x => x.Scope)
            .HasConversion<string>();
    }
}