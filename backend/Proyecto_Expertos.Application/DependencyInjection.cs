using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Proyecto_Expertos.Application;

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        return services;
    }
}