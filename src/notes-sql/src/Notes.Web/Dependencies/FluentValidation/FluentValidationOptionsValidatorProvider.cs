using Microsoft.Extensions.Options;

namespace Notes.Web.Dependencies.FluentValidation;

public sealed class FluentValidationOptionsValidatorProvider<TOptions>(OptionsValidator<TOptions> validator) : IValidateOptions<TOptions> where TOptions : class
{
    private readonly OptionsValidator<TOptions> _validator = validator;

    public ValidateOptionsResult Validate(string? name, TOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        var validationResult = _validator.Validate(options);
        if (validationResult.IsValid is false)
        {
            var errors = validationResult.Errors.Select(error => error.ErrorMessage);
            return ValidateOptionsResult.Fail(errors);
        }

        return ValidateOptionsResult.Success;
    }
}