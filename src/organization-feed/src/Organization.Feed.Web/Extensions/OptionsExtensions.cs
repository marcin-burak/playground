namespace Organization.Feed.Web.Extensions;

internal static class OptionsExtensions
{
    public static TOptions? TryGetOptionsByName<TOptions>(this IConfiguration configuration) where TOptions : class, new()
    {
        var configurationSection = configuration.GetSection(GetOptionsTypeName<TOptions>());
        if (configurationSection is not null)
        {
            var optionsInstance = Activator.CreateInstance<TOptions>();
            configurationSection.Bind(optionsInstance);

            return optionsInstance;
        }

        return null;
    }

    public static TOptions GetOptionsByName<TOptions>(this IConfiguration configuration) where TOptions : class, new()
    {
        var optionsInstance = Activator.CreateInstance<TOptions>();

        configuration.GetRequiredSection(GetOptionsTypeName<TOptions>()).Bind(optionsInstance);

        return optionsInstance;
    }

    public static IServiceCollection AddOptionsByName<TOptions>(this IServiceCollection services, bool skipValidation = false) where TOptions : class, new()
    {
        var options = services.AddOptions<TOptions>().BindConfiguration(GetOptionsTypeName<TOptions>());

        if (skipValidation is false)
        {
            options.ValidateDataAnnotations().ValidateOnStart();
        }

        return services;
    }

    private static string GetOptionsTypeName<TOptions>() where TOptions : class, new() => typeof(TOptions).Name[..^7];
}
