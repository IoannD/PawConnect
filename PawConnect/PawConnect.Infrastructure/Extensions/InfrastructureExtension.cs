using Microsoft.Extensions.DependencyInjection;
using PawConnect.Application;
using PawConnect.Infrastructure.Repositories;

namespace PawConnect.Infrastructure.Extensions;

public static class InfrastructureExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();
        services.AddScoped<IVolunteerRepository, VolunteerRepository>();
        return services;
    }
}