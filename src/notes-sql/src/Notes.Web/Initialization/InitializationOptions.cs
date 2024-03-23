using Microsoft.Extensions.Options;

namespace Notes.Web.Initialization;

public sealed class InitializationOptions
{
    public required bool InitializeOnStartup { get; init; }
}

public sealed class InitializationOptionsValidation : IValidateOptions<InitializationOptions>
{
    public ValidateOptionsResult Validate(string? name, InitializationOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        return ValidateOptionsResult.Success;
    }
}