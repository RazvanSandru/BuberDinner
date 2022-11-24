using BuberDinner.Application.Interfaces.Persistence;
using BuberDinner.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
