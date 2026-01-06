using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tawla._360.Domain.Entities.MenuEntities;

namespace Tawla._360.Persistence.TypeConfiguration.MenuEntityConfiguration;

public class ModifierOptionConfiguration : IEntityTypeConfiguration<ModifierOption>
{
    public void Configure(EntityTypeBuilder<ModifierOption> builder)
    {
        builder.HasMany(x=>x.ModifierOptionPrices).WithOne(x=>x.ModifierOption).HasForeignKey(x=>x.ModifierOptionId).OnDelete(DeleteBehavior.Cascade);
    }
}
