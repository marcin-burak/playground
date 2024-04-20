using Microsoft.Extensions.DependencyInjection;

namespace Todo.Common.FluentValidation;

public static class DependencyInjection
{
    public static IServiceCollection AddFluentValidationConfiguration(this IServiceCollection services)
    {
        FluentValidationGlobalSettings.Setup();
        return services;
    }
}
