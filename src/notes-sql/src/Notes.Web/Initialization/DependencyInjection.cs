using Notes.Web.Dependencies.Options;

namespace Notes.Web.Initialization;

internal static class DependencyInjection
{
    public static IServiceCollection AddInitialization(this IServiceCollection services) => services
        .AddOptionsByConvention<InitializationOptions, InitializationOptionsValidation>()
        .AddScoped<Initialize>();
}
