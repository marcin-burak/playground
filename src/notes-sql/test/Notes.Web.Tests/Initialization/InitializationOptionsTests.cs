using FluentValidation;
using Notes.Web.Initialization;

namespace Notes.Web.Tests.Initialization;

public sealed class InitializationOptionsTests
{
    [Fact]
    public void Ensure_Valid_Cascade_Modes()
    {
        InitializationOptionsValidator validator = new();

        Assert.Equal(CascadeMode.Continue, validator.ClassLevelCascadeMode);
        Assert.Equal(CascadeMode.Continue, validator.RuleLevelCascadeMode);
    }
}