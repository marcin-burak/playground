using Notes.Web.Infrastructure.SqlServer;

namespace Notes.Web.Tests.Infrastructure.SqlServer;

public sealed class SqlServerOptionsTests
{
    [Fact]
    public void ThrowsOnNullOptions()
    {
        Assert.Throws<ArgumentNullException>(() => new SqlServerOptionsValidation().Validate(null, null!));
    }

    [Theory]
    [MemberData(nameof(InvalidOptions))]
    public void ValidationFails(SqlServerOptions options)
    {
        var result = new SqlServerOptionsValidation().Validate(null, options);

        Assert.True(result.Failed);
    }

    [Theory]
    [MemberData(nameof(ValidOptions))]
    public void ValidationSucceeds(SqlServerOptions options)
    {
        var result = new SqlServerOptionsValidation().Validate(null, options);

        Assert.True(result.Succeeded);
    }

    #region Data

    public static TheoryData<SqlServerOptions> InvalidOptions => new()
    {
        {
            new()
            {
                ConnectionString = null!
            }
        },
        {
            new()
            {
                ConnectionString = string.Empty
            }
        },
        {
            new()
            {
                ConnectionString = " "
            }
        },
    };

    public static TheoryData<SqlServerOptions> ValidOptions => new()
    {
        {
            new()
            {
                ConnectionString = "Server=sqlserver,1433;Database=Application;User=sa;Password=P@ssw0rd;TrustServerCertificate=true;"
            }
        },
    };

    #endregion
}