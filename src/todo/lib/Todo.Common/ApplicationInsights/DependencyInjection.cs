using Microsoft.Extensions.DependencyInjection;
using Todo.Common.FluentValidation;

namespace Todo.Common.ApplicationInsights;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationInsightsConfiguration(this IServiceCollection services) => services
        .AddFluentValidationConfiguration()
        .AddOptionsByConvention<ApplicationInsightsOptions>();
}
