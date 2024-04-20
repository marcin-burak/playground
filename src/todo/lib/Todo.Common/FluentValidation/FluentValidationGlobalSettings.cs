using FluentValidation;

namespace Todo.Common.FluentValidation;

public static class FluentValidationGlobalSettings
{
    public static void Setup()
    {
        ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Continue;
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
    }
}
