using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tawla._360.Domain.Entities.UsersEntities;

namespace Tawla._360.Persistence.TypeConfiguration.Users;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.HasIndex(r => new { r.Name, r.RestaurantId })
               .IsUnique();
    }
}
