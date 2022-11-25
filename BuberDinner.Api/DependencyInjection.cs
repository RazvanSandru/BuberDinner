using BuberDinner.Api.Common;
using MediatR;

namespace BuberDinner.Api;
public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddMappings();
		services.AddControllers();
		return services;
    }
}
