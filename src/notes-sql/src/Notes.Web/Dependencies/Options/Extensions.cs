using Microsoft.Extensions.Options;

namespace Notes.Web.Dependencies.Options;

internal static class Extensions
{
    public static IServiceCollection AddOptionsByConvention<TOptions, TValidation>(this IServiceCollection services)
        where TOptions : class
        where TValidation : class, IValidateOptions<TOptions> =>
            services.AddOptionsWithValidateOnStart<TOptions, TValidation>().BindConfiguration(GetOptionsTypeName<TOptions>()).Services;

    public static TOptions GetOptions<TOptions>(this IConfiguration configuration) where TOptions : class
    {
        var optionsInstance = Activator.CreateInstance<TOptions>();
        configuration.GetRequiredSection(GetOptionsTypeName<TOptions>()).Bind(optionsInstance);

        return optionsInstance;
    }

    public static TOptions? TryGetOptions<TOptions>(this IConfiguration configuration) where TOptions : class
    {
        var configurationSection = configuration.GetSection(GetOptionsTypeName<TOptions>());
        if (configurationSection is null)
        {
            return null;
        }

        var optionsInstance = Activator.CreateInstance<TOptions>();
        configurationSection.Bind(optionsInstance);

        return optionsInstance;
    }

    public static IOptions<TOptions> GetOptions<TOptions>(this IServiceProvider serviceProvider) where TOptions : class => serviceProvider
        .GetRequiredService<IOptions<TOptions>>();

    private static string GetOptionsTypeName<TOptions>() => typeof(TOptions).Name[..^7];
}
