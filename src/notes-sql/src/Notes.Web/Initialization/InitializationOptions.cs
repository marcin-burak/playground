using Notes.Web.Dependencies.FluentValidation;

namespace Notes.Web.Initialization;

public sealed class InitializationOptions
{
    public bool InitializeOnStartup { get; set; }
}

public sealed class InitializationOptionsValidator : OptionsValidator<InitializationOptions>
{
    public InitializationOptionsValidator() : base()
    {

    }
}