using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tawla._360.Domain.Repositories;
using Tawla._360.Infrastructure.Repositories;
using Tawla._360.Persistence;

namespace Tawla._360.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterPersistence(configuration);
        services.AddRepos();
        return services;
    }
    private static IServiceCollection AddRepos(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IHasIdRepository<>), typeof(HasIdRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        // services.AddScoped(TypeLoadException)
        return services;
    }
}
