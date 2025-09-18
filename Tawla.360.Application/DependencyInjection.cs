using Microsoft.Extensions.DependencyInjection;

namespace Tawla._360.Application;

public class DependencyInjection
{
    public static IServiceCollection RegisterApplication(IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddAutoMapper(assembly);
        return services;
    }
}
