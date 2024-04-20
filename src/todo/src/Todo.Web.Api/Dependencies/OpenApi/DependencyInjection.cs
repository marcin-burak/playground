using Todo.Common;

namespace Todo.Web.Api.Dependencies.OpenApi;

internal static class DependencyInjection
{
    public static IServiceCollection AddOpenApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptionsByConvention<OpenApiOptions, OpenApiOptionsValidator>();

        var openApiOptions = configuration.GetOptionsByConvention<OpenApiOptions>();
        if (openApiOptions.Enabled)
        {
            services
                .AddEndpointsApiExplorer()
                .AddSwaggerGen();
        }

        return services;
    }
}
