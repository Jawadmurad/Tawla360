using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Persistence.TypeConfiguration.MenuEntityConfiguration;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.OwnsMany(c => c.Translations, t =>
        {
            t.HasKey("ItemId",nameof(ItemTranslation.PropertyName),nameof(ItemTranslation.LanguageCode));
            t.ToTable("ItemTranslation");
            t.Property(p=>p.PropertyName).IsRequired();
            t.Property(p=>p.LanguageCode).IsRequired();
            t.Property(p=>p.Value).IsRequired();
        });
        builder.Navigation(x=>x.Translations).AutoInclude();
    }
}
