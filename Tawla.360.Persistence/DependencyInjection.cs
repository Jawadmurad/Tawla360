using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tawla._360.Domain.Entities.RestaurantEntities;
using Tawla._360.Domain.Entities.UsersEntities;
using Tawla._360.Persistence.DbContexts;
using Tawla._360.Persistence.EfCoreOverride.Stores;
using Tawla._360.Persistence.EfCoreOverride.Validator;
using Tawla._360.Persistence.Fakers;

namespace Tawla._360.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection RegisterPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            // options.UseAsyncSeeding(async (context, _, ct) =>
            // {
            //     var randomizer = 1716;
            //     var fakeRestaurants = new RestaurantFaker(new BranchFaker("ar",randomizer),"ar",randomizer).Generate(50);
            //     if (!await context.Set<Restaurant>().AnyAsync(ct))
            //     {
            //         await context.Set<Restaurant>().AddRangeAsync(fakeRestaurants, ct);
            //         await context.SaveChangesAsync(ct);
            //     }
            // });
        })
        .AddIdentity<ApplicationUser, ApplicationRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddRoleStore<RestaurantRoleStore>()
        .AddRoleValidator<RestaurantRoleValidator>()
        .AddDefaultTokenProviders();
        return services;
    }
}
