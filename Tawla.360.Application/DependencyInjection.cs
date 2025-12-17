using Microsoft.Extensions.DependencyInjection;
using Tawla._360.Application.AuthUseCases;
using Tawla._360.Application.BranchUseCases;
using Tawla._360.Application.CategoryUseCases;
using Tawla._360.Application.Common.ServicesInterfaces;
using Tawla._360.Application.DisCountUseCases;
using Tawla._360.Application.ItemUseCases;
using Tawla._360.Application.ModifierGroupUserCase;
using Tawla._360.Application.ModifierUseCases;
using Tawla._360.Application.RestaurantUseCases;
using Tawla._360.Application.RoleUseCases;
using Tawla._360.Application.Services;
using Tawla._360.Application.TableUseCases;
using Tawla._360.Application.SurchargeUseCase;
using Tawla._360.Application.TaxesUseCases;
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
        services.AddScoped<ITaxService, TaxService>();
        services.AddScoped<IDiscountService, DiscountService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IModifierService, ModifierService>();
        services.AddScoped<ITableService, TableService>();
        services.AddScoped<IItemService,ItemService>();
        services.AddScoped<IModifierService,ModifierService>();
        services.AddScoped<IModifierGroupService,ModifierGroupService>();
        services.AddScoped<ISurchargeService,SurchargeService>();
        return services;
    }
}
