using Notes.Web.Initialization;

namespace Notes.Web.Tests.Initialization;

public sealed class InitializationOptionsTests
{
    [Fact]
    public void ThrowsOnNullOptions()
    {
        Assert.Throws<ArgumentNullException>(() => new InitializationOptionsValidation().Validate(null, null!));
    }
}
