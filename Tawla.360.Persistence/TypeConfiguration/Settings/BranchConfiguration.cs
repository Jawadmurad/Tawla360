using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tawla._360.Domain.Entities.RestaurantEntities;

namespace Tawla._360.Persistence.TypeConfiguration.Settings;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        //builder.HasMany(x => x.BranchTaxes).WithOne(x => x.Branch).HasForeignKey(x => x.BranchId).OnDelete(DeleteBehavior.Cascade);

    }
}
