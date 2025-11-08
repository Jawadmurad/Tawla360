using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tawla._360.Domain.Entities.RestaurantEntities;

namespace Tawla._360.Persistence.TypeConfiguration.RestaurantEntitiesConfiguration;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.Property(x => x.InsertionDefaultLanguage)
        .HasColumnType("char(4)")
        .IsRequired();

    }
}
