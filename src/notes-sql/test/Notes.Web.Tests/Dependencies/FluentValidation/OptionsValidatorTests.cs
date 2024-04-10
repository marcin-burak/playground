using FluentValidation;
using Notes.Web.Dependencies.FluentValidation;

namespace Notes.Web.Tests.Dependencies.FluentValidation;

public sealed class OptionsValidatorTests
{
    [Fact]
    public void Ensure_Valid_Cascade_Modes()
    {
        SampleOptionsValidator validator = new();

        Assert.Equal(CascadeMode.Continue, validator.ClassLevelCascadeMode);
        Assert.Equal(CascadeMode.Continue, validator.RuleLevelCascadeMode);
    }



    #region Test data

    private class SampleOptionsValidator : OptionsValidator<object>
    {
        public SampleOptionsValidator() : base() { }
    }

    #endregion
}
