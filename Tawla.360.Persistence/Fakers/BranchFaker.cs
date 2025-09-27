using Bogus;
using Tawla._360.Domain.Entities.RestaurantEntities;

namespace Tawla._360.Persistence.Fakers;

public class BranchFaker : Faker<Branch>
{
    public BranchFaker(string locale = "ar", int? seed = null)
    {
        if (seed.HasValue)
            UseSeed(seed.Value);
        RuleFor(b => b.Id, f => Guid.NewGuid())
            .RuleFor(b => b.Number, f => f.Random.Int(1, 100))
            .RuleFor(b => b.Location, f => f.Address.FullAddress());

    }
}
