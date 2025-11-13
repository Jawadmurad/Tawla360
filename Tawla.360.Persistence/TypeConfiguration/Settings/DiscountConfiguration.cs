using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tawla._360.Domain.Entities.Settings;

namespace Tawla._360.Persistence.TypeConfiguration.Settings;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.OwnsMany(d => d.Translations, t =>
        {
            // WithOwner() automatically sets the FK
            // Can define a composite key for uniqueness
            t.HasKey("DiscountId", nameof(DiscountTranslation.PropertyName), nameof(DiscountTranslation.LanguageCode));

            // Optional: table name
            t.ToTable("DiscountTranslations");

            // Optional: configure required properties
            t.Property(p => p.PropertyName).IsRequired();
            t.Property(p => p.LanguageCode).IsRequired();
            t.Property(p => p.Value).IsRequired();
        });
        builder.Navigation(x => x.Translations).AutoInclude();
    }
}
