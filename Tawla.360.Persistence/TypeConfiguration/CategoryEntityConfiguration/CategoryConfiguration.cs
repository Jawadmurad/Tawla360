using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Persistence.TypeConfiguration.CategoryEntityConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.OwnsMany(c => c.Translations, t =>
        {
            t.HasKey("CategoryId",nameof(CategoryTranslation.PropertyName),nameof(CategoryTranslation.LanguageCode));
            t.ToTable("CategoryTranslation");
            t.Property(p=>p.PropertyName).IsRequired();
            t.Property(p=>p.LanguageCode).IsRequired();
            t.Property(p=>p.Value).IsRequired();
        });
        builder.Navigation(x=>x.Translations).AutoInclude();
    }
}
