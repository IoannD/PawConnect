using Microsoft.Extensions.DependencyInjection;
using PawConnect.Application.VolunteerCases;

namespace PawConnect.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateVolunteerUseCase>();
        return services;
    }
}