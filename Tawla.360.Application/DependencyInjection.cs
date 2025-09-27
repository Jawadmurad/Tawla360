using Microsoft.Extensions.DependencyInjection;
using Tawla._360.Application.RestaurantUseCases;
using Tawla._360.Application.UsersUseCases;

namespace Tawla._360.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddAutoMapper(assembly);
        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
