using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Common.FluentValidation;

namespace Todo.Common;

public static class Extensions
{
    public static IServiceCollection AddOptionsByConvention<TOptions>(this IServiceCollection services) where TOptions : class
    {
        services.AddOptionsWithValidateOnStart<TOptions, ConfigurationOptionsValidator<TOptions>>().BindConfiguration(GetOptionsSectionName<TOptions>());
        services.AddSingleton(serviceProvider =>
        {
            var optionsTypeAssembly = typeof(TOptions).Assembly;
            var optionsValidatorBaseType = typeof(AbstractValidator<>).MakeGenericType(typeof(TOptions));
            var optionsValidatorType = optionsTypeAssembly.GetTypes().SingleOrDefault(type => type.IsClass && type.IsAssignableTo(optionsValidatorBaseType));

            if (optionsValidatorType is null)
            {
                throw new InvalidOperationException($"Failed to find validator for '{typeof(TOptions).FullName}' options.");
            }

            var validator = (IValidator<TOptions>)ActivatorUtilities.GetServiceOrCreateInstance(serviceProvider, optionsValidatorType);

            return validator;
        });

        return services;
    }

    public static TOptions GetOptionsByConvention<TOptions>(this IConfiguration configuration) where TOptions : class =>
        GetOptions<TOptions>(configuration, configuationSectionRequired: true)!;

    public static TOptions? TryGetOptionsByConvention<TOptions>(this IConfiguration configuration) where TOptions : class =>
        GetOptions<TOptions>(configuration, configuationSectionRequired: false);



    private static string GetOptionsSectionName<TOptions>() where TOptions : class => typeof(TOptions).Name[..^7];

    private static TOptions? GetOptions<TOptions>(IConfiguration configuration, bool configuationSectionRequired) where TOptions : class
    {
        ArgumentNullException.ThrowIfNull(configuration);

        IConfigurationSection configurationSection;

        if (configuationSectionRequired)
        {
            configurationSection = configuration.GetRequiredSection(GetOptionsSectionName<TOptions>());
        }
        else
        {
            configurationSection = configuration.GetSection(GetOptionsSectionName<TOptions>());
        }

        if (configurationSection is null)
        {
            return null;
        }

        var optionsInstance = Activator.CreateInstance<TOptions>();

        configurationSection.Bind(optionsInstance);

        return optionsInstance;
    }
}
