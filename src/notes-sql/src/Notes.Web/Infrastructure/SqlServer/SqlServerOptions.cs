using Microsoft.Extensions.Options;

namespace Notes.Web.Infrastructure.SqlServer;

public sealed class SqlServerOptions
{
    public required string ConnectionString { get; init; } = string.Empty;
}

public sealed class SqlServerOptionsValidation : IValidateOptions<SqlServerOptions>
{
    public ValidateOptionsResult Validate(string? name, SqlServerOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        if (string.IsNullOrWhiteSpace(options.ConnectionString))
        {
            return ValidateOptionsResult.Fail("SQL Server connection string is required.");
        }

        return ValidateOptionsResult.Success;
    }
}