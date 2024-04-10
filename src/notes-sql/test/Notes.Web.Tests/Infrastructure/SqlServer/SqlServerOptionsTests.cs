using FluentValidation;
using FluentValidation.TestHelper;
using Notes.Web.Infrastructure.SqlServer;

namespace Notes.Web.Tests.Infrastructure.SqlServer;

public sealed class SqlServerOptionsTests
{
    [Fact]
    public void Ensure_Valid_Cascade_Modes()
    {
        SqlServerOptionsValidator validator = new();

        Assert.Equal(CascadeMode.Continue, validator.ClassLevelCascadeMode);
        Assert.Equal(CascadeMode.Continue, validator.RuleLevelCascadeMode);
    }

    [Theory]
    [MemberData(nameof(ValidOptions))]
    public void ValidationSucceeds(SqlServerOptions options)
    {
        var validationResult = new SqlServerOptionsValidator().TestValidate(options);
        validationResult.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [MemberData(nameof(InvalidOptions))]
    public void ValidationFails(SqlServerOptions options)
    {
        var validationResult = new SqlServerOptionsValidator().TestValidate(options);
        validationResult.ShouldHaveAnyValidationError();
    }



    #region Test data

    public static TheoryData<SqlServerOptions> ValidOptions => new()
    {
        {
            new()
            {
                ConnectionString = "Server=sqlserver,1433;Database=Application;User=sa;Password=P@ssw0rd;TrustServerCertificate=true;"
            }
        },
        {
            new()
            {
                ConnectionString = "Server=sqlserver,1433;Database=Application;"
            }
        },
        {
            new()
            {
                ConnectionString = "Database=Application;Server=sqlserver,1433;"
            }
        },
    };

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
        {
            new()
            {
                ConnectionString = " Server=sqlserver,1433;Database=Application;User=sa;Password=P@ssw0rd;TrustServerCertificate=true; "
            }
        },
        {
            new()
            {
                ConnectionString = "User=sa;Password=P@ssw0rd;TrustServerCertificate=true;"
            }
        },
        {
            new()
            {
                ConnectionString = "Server=sqlserver,1433;User=sa;Password=P@ssw0rd;TrustServerCertificate=true;"
            }
        },
        {
            new()
            {
                ConnectionString = "Database=Application;User=sa;Password=P@ssw0rd;TrustServerCertificate=true;"
            }
        },
    };

    #endregion
}