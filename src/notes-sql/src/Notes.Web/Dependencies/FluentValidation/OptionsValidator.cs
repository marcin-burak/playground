using FluentValidation;

namespace Notes.Web.Dependencies.FluentValidation;

//TODO: Check out property name
public abstract class OptionsValidator<TOptions> : AbstractValidator<TOptions> where TOptions : class
{
    protected OptionsValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Continue;
        RuleLevelCascadeMode = CascadeMode.Continue;
    }
}
