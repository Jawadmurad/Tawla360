using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Persistence.TypeConfiguration.MenuEntityConfiguration;

public class ModifierGroupConfiguration : IEntityTypeConfiguration<ModifierGroup>
{
    public void Configure(EntityTypeBuilder<ModifierGroup> builder)
    {
        builder.OwnsMany(c => c.Translations, t =>
        {
            t.HasKey("ModifierGroupId",nameof(ModifierGroupTranslation.PropertyName),nameof(ModifierGroupTranslation.LanguageCode));
            t.ToTable("ModifierGroupTranslation");
            t.Property(p=>p.PropertyName).IsRequired();
            t.Property(p=>p.LanguageCode).IsRequired();
            t.Property(p=>p.Value).IsRequired();
        });
        builder.Navigation(x=>x.Translations).AutoInclude();
        builder.HasMany(x=>x.Options).WithOne(x=>x.ModifierGroup).HasForeignKey(x=>x.ModifierGroupId).OnDelete(DeleteBehavior.Cascade);
    }
}
