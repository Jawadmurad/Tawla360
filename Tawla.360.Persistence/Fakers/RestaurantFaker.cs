using Bogus;
using Tawla._360.Domain.Entities.RestaurantEntities;

namespace Tawla._360.Persistence.Fakers;

public class RestaurantFaker : Faker<Restaurant>
{
    public RestaurantFaker(BranchFaker branchFaker,string locale = "ar", int? seed = null)
    {
        if (seed.HasValue)
            UseSeed(seed.Value);
            RuleFor(r => r.Id, f => Guid.NewGuid())
            .RuleFor(r => r.Name, f => f.Company.CompanyName())
            .RuleFor(r => r.Description, f => f.Lorem.Sentence(10))
            .RuleFor(r => r.Logo, f => f.Image.PicsumUrl(200, 200, true))
            .RuleFor(r => r.NumberOfBranches, _ => 1)
            .RuleFor(r => r.CloseTime, f => TimeOnly.FromDateTime(f.Date.Between(
                                        DateTime.Today.AddHours(20),
                                        DateTime.Today.AddHours(23))))
            .RuleFor(r => r.IsActive, f => f.Random.Bool())
            .RuleFor(r => r.Branches, (f, r) =>
            {
                var branch = branchFaker.Generate();
                branch.RestaurantId = r.Id;
                return [branch];
            });
    }
}
