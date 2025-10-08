using Microsoft.Extensions.DependencyInjection;
using Tawla._360.Application.AuthUseCases;
using Tawla._360.Application.BranchUseCases;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.RestaurantUseCases;
using Tawla._360.Application.RoleUseCases;
using Tawla._360.Application.Services;
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
        services.AddScoped<IBranchService, BranchService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IHttpContextAccessorService, HttpContextAccessorService>();
        return services;
    }
}
