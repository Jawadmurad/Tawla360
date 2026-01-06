using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Persistence.TypeConfiguration.MenuEntityConfiguration;

public class ModifierConfiguration : IEntityTypeConfiguration<Modifier>
{
    public void Configure(EntityTypeBuilder<Modifier> builder)
    {
        builder.OwnsMany(c => c.Translations, t =>
        {
            t.HasKey("ModifierId",nameof(ModifierTranslation.PropertyName),nameof(ModifierTranslation.LanguageCode));
            t.ToTable("ModifierTranslation");
            t.Property(p=>p.PropertyName).IsRequired();
            t.Property(p=>p.LanguageCode).IsRequired();
            t.Property(p=>p.Value).IsRequired();
        });
        builder.Navigation(x=>x.Translations).AutoInclude();
    }
}
